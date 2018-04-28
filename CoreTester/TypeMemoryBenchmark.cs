using System;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester
{
    [Config(typeof(Config))]
    public class TypeMemoryBenchmark
    {
        private readonly int count = 10 * 1000 * 1000;
        private PointClass[] collectionOfClasses;
        private PointStruct[] collectionOfStructs;

        [Benchmark]
        public PointClass[] CreateCollectionOfClasses()
        {
            for (int i = 0; i < count; i++)
            {
                collectionOfClasses[i] = new PointClass { X = i, Y = i };
            }

            return collectionOfClasses;
        }

        [Benchmark]
        public PointStruct[] CreateCollectionOfStructs()
        {
            for (int i = 0; i < count; i++)
            {
                collectionOfStructs[i] = new PointStruct { X = i, Y = i };
            }

            return collectionOfStructs;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            collectionOfClasses = new PointClass[count];
            collectionOfStructs = new PointStruct[count];
        }
    }
}
