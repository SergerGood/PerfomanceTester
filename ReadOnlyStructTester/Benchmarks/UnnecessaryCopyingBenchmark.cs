using System;
using BenchmarkDotNet.Attributes;
using ReadOnlyStructTester.Configuration;

namespace ReadOnlyStructTester.Benchmarks
{
    [Config(typeof(Config))]
    public class UnnecessaryCopyingBenchmark
    {
        private ExtendedReadonlyStruct[] arrayOfExtendedReadonlyStructs;
        private ReadOnlyStruct[] arrayOfReadonlyStructs;

        [Params(100_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public bool Equals()
        {
            ReadOnlyStruct current = arrayOfReadonlyStructs[0];
            var result = false;

            foreach (ReadOnlyStruct readOnlyStruct in arrayOfReadonlyStructs)
            {
                result = current == readOnlyStruct;
            }

            return result;
        }

        [Benchmark]
        public bool ExtendedEquals()
        {
            ExtendedReadonlyStruct current = arrayOfExtendedReadonlyStructs[0];
            var result = false;

            foreach (ExtendedReadonlyStruct readOnlyStruct in arrayOfExtendedReadonlyStructs)
            {
                result = current == readOnlyStruct;
            }

            return result;
        }

        [GlobalSetup]
        public void Setup()
        {
            arrayOfReadonlyStructs = new ReadOnlyStruct[ElementsCount];
            arrayOfExtendedReadonlyStructs = new ExtendedReadonlyStruct[ElementsCount];

            for (var i = 0; i < ElementsCount; i++)
            {
                arrayOfReadonlyStructs[i] = new ReadOnlyStruct(i, i + 1);
            }

            for (var i = 0; i < ElementsCount; i++)
            {
                arrayOfExtendedReadonlyStructs[i] = new ExtendedReadonlyStruct(i, i + 1);
            }
        }
    }
}
