using System;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester
{
    [Config(typeof(Config))]
    public class CopyBenchmark
    {
        [Params(100_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass Classes()
        {
            PointClass element = new PointClass { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyClass(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct RefStructes()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyRefStruct(in element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct Structes()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyStruct(element);
            }

            return element;
        }

        private PointClass CopyClass(PointClass element)
        {
            return element;
        }

        private PointStruct CopyRefStruct(in PointStruct element)
        {
            return element;
        }

        private PointStruct CopyStruct(PointStruct element)
        {
            return element;
        }
    }
}
