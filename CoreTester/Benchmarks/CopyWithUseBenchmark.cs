using System;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CopyWithUseBenchmark
    {
        [Params(100_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass CopyClasses()
        {
            PointClass element = new PointClass { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct CopyRefStruct()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CalculateRef(in element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct CopyStruct()
        {
            PointStruct element = new PointStruct { X = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        private int Calculate(PointClass element)
        {
            return element.X + element.Y;
        }

        private int CalculateRef(in PointStruct element)
        {
            return element.X + element.Y;
        }

        private int Calculate(PointStruct element)
        {
            return element.X + element.Y;
        }
    }
}
