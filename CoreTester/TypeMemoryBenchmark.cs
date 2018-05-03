using System;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester
{
    [Config(typeof(Config))]
    public class TypeMemoryBenchmark
    {
        private PointClass[] collectionOfClasses;
        private PointStruct[] collectionOfStructs;

        [Params(1_000_000, 10_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass[] CreateCollectionOfClasses()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                collectionOfClasses[i] = new PointClass { X = i, Y = i };
            }

            return collectionOfClasses;
        }

        [Benchmark]
        public PointStruct[] CreateCollectionOfStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                collectionOfStructs[i] = new PointStruct { X = i, Y = i };
            }

            return collectionOfStructs;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            collectionOfClasses = new PointClass[ElementsCount];
            collectionOfStructs = new PointStruct[ElementsCount];
        }
    }
}
