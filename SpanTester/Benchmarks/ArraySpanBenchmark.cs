using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using SpanTester.Configuration;

namespace SpanTester.Benchmarks
{
    [Config(typeof(Config))]
    public class ArraySpanBenchmark
    {
        protected const int Loops = 100;
        protected const int Count = 1000;

        protected byte[] arrayField;

        [GlobalSetup]
        public void Setup()
        {
            arrayField = Enumerable.Repeat(1, Count).Select((val, index) => (byte)index).ToArray();
        }

        [Benchmark(OperationsPerInvoke = Loops * Count)]
        public byte SpanIndexerGet()
        {
            Span<byte> local = arrayField.AsSpan();
            byte result = 0;
            for (var _ = 0; _ < Loops; _++)
            {
                for (var j = 0; j < local.Length; j++)
                {
                    result = local[j];
                }
            }

            return result;
        }

        [Benchmark(OperationsPerInvoke = Loops * Count)]
        public byte ArrayIndexerGet()
        {
            byte[] local = arrayField;
            byte result = 0;
            for (var _ = 0; _ < Loops; _++)
            {
                for (var j = 0; j < local.Length; j++)
                {
                    result = local[j];
                }
            }

            return result;
        }
    }
}
