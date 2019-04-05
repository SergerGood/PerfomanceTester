using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ParallelTester.Configuration;
using TypeTester;

namespace ParallelTester.Benchmarks
{
    [Config(typeof(Config))]
    public class ParallelUseBenchmark
    {
        private Item[] nodes;

        private int[][] nodeIndexMap;
        private byte[] linksBuffer;

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

            nodeIndexMap = new int[ElementsCount][];
            linksBuffer = GetLinksBuffer();

            for (var i = 0; i < ElementsCount; i++)
            {
                Generate(i, linksBuffer);
            }
        }

        [Benchmark]
        public int[][] For()
        {
            foreach (Item node in nodes)
            {
                Process(node);
            }

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForEach()
        {
            Parallel.ForEach(nodes,
                parallelOptions,
                node =>
                {
                    Process(node);
                });

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForEachPartition()
        {
            OrderablePartitioner<Item> orderablePartitioner = Partitioner.Create(nodes, true);

            Parallel.ForEach(orderablePartitioner,
                parallelOptions,
                node =>
                {
                    Process(node);
                });

            return nodeIndexMap;
        }

        [Benchmark]
        public int[][] ParallelForEachPartition2()
        {
            OrderablePartitioner<Tuple<int, int>> orderablePartitioner = Partitioner.Create(0, nodes.Length, 100);

            Parallel.ForEach(orderablePartitioner,
                node =>
                {
                    for (int i = node.Item1; i < node.Item2; i++)
                    {
                        Process(nodes[i]);
                    }
                });

            return nodeIndexMap;
        }

        private byte[] GetLinksBuffer()
        {
            var linksBufferSize = (int)Math.Ceiling((decimal)ElementsCount * (ElementsCount + 1) / (2 * 8.0M));
            return new byte[linksBufferSize];
        }

        private void Generate(int i, byte[] linksBuffer)
        {
            Item item = nodes[i];

            int index = (int)(((long)i + 1) * i / 2 + i) >> 3;

            linksBuffer[index >> 3] |= (byte)(0x80 >> (index & 0x7));

            nodeIndexMap[item.Id] = new int[] { i + 1 };
        }

        private void Process(in Item node)
        {
            int i = nodeIndexMap[node.Id][0];

            foreach (var link in node.Links)
            {
                int j = nodeIndexMap[link][0];

                int index;
                if (i < j)
                {
                    index = (int)(j * ((long)j - 1) / 2 + i - 1);
                }
                else
                {
                    index = (int)(i * ((long)i - 1) / 2 + j - 1);
                }

                linksBuffer[index >> 3] |= (byte)((0x80 >> index) & 0x7);
            }
        }
    }
}
