using System;
using ArrayPoolTester.Benchmarks;
using BenchmarkDotNet.Running;

namespace ArrayPoolTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(PoolingVsAllocationBenchmark)
            });

            switcher.Run(args);


            //var benchmark = new PoolingVsAllocationBenchmark { N = 100000 };
            //benchmark.Rent();
        }
    }
}
