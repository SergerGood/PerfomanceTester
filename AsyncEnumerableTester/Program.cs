using System;
using AsyncEnumerableTester.Benchmarks;
using BenchmarkDotNet.Running;

namespace AsyncEnumerableTester
{
    class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(Benchmark)
            });

            switcher.Run(args);


            //var benchmark = new Benchmark();
            //benchmark.GetListAsync();
        }
    }
}
