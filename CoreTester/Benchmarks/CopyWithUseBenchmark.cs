using System;
using BenchmarkDotNet.Attributes;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CopyWithUseBenchmark
    {
        [Params(1_000_000)]
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
        public PointStruct Structs()
        {
            var element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct StructsByRef()
        {
            var element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CalculateByRef(ref element);
            }

            return element;
        }

        [Benchmark]
        public PointReadonlyStruct ReadonlyStructs()
        {
            var element = new PointReadonlyStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                Calculate(element);
            }

            return element;
        }

        [Benchmark]
        public PersonRecord Records()
        {
            PersonRecord element = new PersonRecord { X = 1, Y = 1 };
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyRecord(element);
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

        private PointStruct CalculateByRef(ref PointStruct element)
        {
            int calc = element.X + element.Y;

            return element;
        }

        private PointReadonlyStruct Calculate(in PointReadonlyStruct element)
        {
            int calc = element.X + element.Y;

            return element;
        }

        private PersonRecord CopyRecord(PersonRecord element)
        {
            int calc = element.X + element.Y;

            return element;
        }

    }
}
