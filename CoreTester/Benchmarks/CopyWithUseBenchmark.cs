using System;
using BenchmarkDotNet.Attributes;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CopyWithUseBenchmark
    {
        [Params(100_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass Classes()
        {
            var element = new PointClass(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct Structes()
        {
            var element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct RefStructes()
        {
            var element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CalculateRef(element);
            }

            return element;
        }

        [Benchmark]
        public PointReadonlyStruct RefReadonlyStructes()
        {
            var element = new PointReadonlyStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        private PointClass Calculate(PointClass element)
        {
            int calc = element.X + element.Y;

            return element;
        }

        private PointStruct Calculate(PointStruct element)
        {
            int calc = element.X + element.Y;

            return element;
        }

        private PointReadonlyStruct Calculate(in PointReadonlyStruct element)
        {
            int calc = element.X + element.Y;

            return element;
        }

        private PointStruct CalculateRef(in PointStruct element)
        {
            int calc = element.X + element.Y;

            return element;
        }
    }
}
