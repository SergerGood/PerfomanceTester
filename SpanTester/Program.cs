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
                typeof(SpanBenchmark)
            });

            switcher.Run(args);
        }
    }
}
