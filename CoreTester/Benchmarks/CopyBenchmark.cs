using System;
using BenchmarkDotNet.Attributes;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CopyBenchmark
    {
        [Params(1_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass Classes()
        {
            PointClass element = new PointClass(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyClass(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct Structs()
        {
            PointStruct element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyStruct(element);
            }

            return element;
        }

        [Benchmark]
        public PointStruct StructsByRef()
        {
            PointStruct element = new PointStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyStructByRef(ref element);
            }

            return element;
        }

        [Benchmark]
        public PointReadonlyStruct ReadonlyStructs()
        {
            PointReadonlyStruct element = new PointReadonlyStruct(1, 1);
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyRefStruct(element);
            }

            return element;
        }

        [Benchmark]
        public PersonRecord Records()
        {
            PersonRecord element = new PersonRecord{ X = 1, Y = 1};
            for (int i = 0; i < ElementsCount; i++)
            {
                CopyRecord(element);
            }

            return element;
        }

        private PointClass CopyClass(PointClass element)
        {
            return element;
        }

        private PointReadonlyStruct CopyRefStruct(in PointReadonlyStruct element)
        {
            return element;
        }

        private PointStruct CopyStruct(PointStruct element)
        {
            return element;
        }

        private PointStruct CopyStructByRef(ref PointStruct element)
        {
            return element;
        }

        private PersonRecord CopyRecord(PersonRecord element)
        {
            return element;
        }
    }
}
