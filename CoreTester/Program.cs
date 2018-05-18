using System;
using BenchmarkDotNet.Running;
using CoreTester.Benchmarks;

namespace CoreTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(CollectionsBenchmark),
                typeof(CopyBenchmark),
                typeof(CopyWithUseBenchmark)
            });

            switcher.Run(args);
        }
    }
}
