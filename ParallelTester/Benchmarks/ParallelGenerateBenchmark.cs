using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ParallelTester.Configuration;
using TypeTester;

namespace ParallelTester.Benchmarks
{
    [Config(typeof(Config))]
    public class ParallelGenerateBenchmark
    {
        private Item[] nodes;

        private static readonly ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

        [Params(65_000)]
        public int ElementsCount { get; set; }

        [Params(1_000)]
        public int LinkedElementsCount { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            nodes = new Item[ElementsCount];

            for (var i = 0; i < ElementsCount; i++)
            {
                var links = new int[LinkedElementsCount];
                for (int j = 0; j < LinkedElementsCount; j++)
                {
                    links[j] = j;
                }
                nodes[i] = new Item(i, links);
            }
        }

        [Benchmark]
        public int[][] For()
        {
            var nodeIndexMap = new int[ElementsCount][];
            byte[] linksBuffer = GetLinksBuffer();

            for (var i = 0; i < ElementsCount; i++)
            {
                Process(i, linksBuffer, nodeIndexMap);
            }

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelFor()
        {
            var nodeIndexMap = new int[ElementsCount][];
            byte[] linksBuffer = GetLinksBuffer();

            Parallel.For(0, ElementsCount,
                parallelOptions,
                i =>
                {
                    Process(i, linksBuffer, nodeIndexMap);
                });

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForPartition()
        {
            var nodeIndexMap = new int[ElementsCount][];
            byte[] linksBuffer = GetLinksBuffer();

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = Partitioner.Create(0, ElementsCount, 1000);

            Parallel.ForEach(rangePartitioner,
                parallelOptions,
                range =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        Process(i, linksBuffer, nodeIndexMap);
                    }
                });

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForPartition2()
        {
            var nodeIndexMap = new int[ElementsCount][];
            byte[] linksBuffer = GetLinksBuffer();

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = Partitioner.Create(0, ElementsCount, 1000);

            Parallel.ForEach(rangePartitioner,
                parallelOptions,
                range =>
                {
                    var items = new LocalItem2[range.Item2 - range.Item1];
                    int j = 0;

                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        items[j] = Process2(ref i, linksBuffer);
                        j++;
                    }

                    foreach (LocalItem2 localItem in items)
                    {
                        nodeIndexMap[localItem.ItemId] = new int[1] { localItem.I + 1 };
                    }
                });

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForPartition3()
        {
            var nodeIndexMap = new int[ElementsCount][];
            byte[] linksBuffer = GetLinksBuffer();

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = Partitioner.Create(0, ElementsCount, 1000);

            Parallel.ForEach(rangePartitioner,
                parallelOptions,
                range =>
                {
                    var items = new LocalItem3[range.Item2 - range.Item1];
                    int j = 0;

                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        items[j] = Process3(ref i);
                        j++;
                    }

                    foreach (LocalItem3 localItem in items)
                    {
                        nodeIndexMap[localItem.ItemId] = new int[1] { localItem.I + 1 };
                        linksBuffer[localItem.LinkBufferIndex] |= localItem.LinkBufferValue;
                    }
                });

            return nodeIndexMap;
        }

        private readonly struct LocalItem2
        {
            public LocalItem2(int itemId, ref int i)
            {
                ItemId = itemId;
                I = i;
            }

            public int ItemId {get;}
            public int I { get; }
        }

        private readonly struct LocalItem3
        {
            public LocalItem3(int itemId, ref int i, int linkBufferIndex, byte linkBufferValue)
            {
                ItemId = itemId;
                I = i;
                LinkBufferIndex = linkBufferIndex;
                LinkBufferValue = linkBufferValue;
            }

            public int ItemId { get; }
            public int I { get; }
            public int LinkBufferIndex { get; }
            public byte LinkBufferValue { get; }
        }

        private byte[] GetLinksBuffer()
        {
            var linksBufferSize = (int)Math.Ceiling((decimal)ElementsCount * (ElementsCount + 1) / (2 * 8.0M));
            return new byte[linksBufferSize];
        }

        private void Process(int i, byte[] linksBuffer, int[][] nodeIndexMap)
        {
            Item item = nodes[i];

            int index = (int)(((long)i + 1) * i / 2 + i) >> 3;

            linksBuffer[index >> 3] |= (byte)(0x80 >> (index & 0x7));

            nodeIndexMap[item.Id] = new int[1] { i + 1 };
        }

        private LocalItem2 Process2(ref int i, byte[] linksBuffer)
        {
            Item item = nodes[i];

            int index = (int)(((long)i + 1) * i / 2 + i) >> 3;

            linksBuffer[index >> 3] |= (byte)(0x80 >> (index & 0x7));

            return new LocalItem2(item.Id, ref i);
        }

        private LocalItem3 Process3(ref int i)
        {
            Item item = nodes[i];

            int index = (int)(((long)i + 1) * i / 2 + i) >> 3;

            return new LocalItem3(item.Id, ref i, index >> 3, (byte)(0x80 >> (index & 0x7)));
        }
    }
}
