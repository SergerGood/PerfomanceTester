using System;
using BenchmarkDotNet.Running;
using SpanTester.Benchmarks;

namespace SpanTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(CharSpanBenchmark),
                typeof(ArraySpanBenchmark),
                typeof(SubstringBenchmark)
            });

            switcher.Run(args);
        }
    }
}
