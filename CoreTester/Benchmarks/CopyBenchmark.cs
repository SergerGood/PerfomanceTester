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
        public PointClass CopyClasses()
        {
            PointClass element = new PointClass { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyClassesCore(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct CopyRefStruct()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyRefStructCore(in element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct CopyStruct()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyStructCore(element);
            }

            return element;
        }

        private void CopyClassesCore(PointClass element)
        {
            
        }

        private void CopyRefStructCore(in PointStruct element)
        {
            
        }

        private void CopyStructCore(PointStruct element)
        {
            
        }
    }
}
