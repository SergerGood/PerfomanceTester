using System;
using BenchmarkDotNet.Running;
using ParallelTester.Benchmarks;

namespace ParallelTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(ParallelGenerateBenchmark),
                typeof(ParallelUseBenchmark)
            });

            switcher.Run(args);

            //var asd = new ParallelUseBenchmark();
            //asd.ElementsCount = 65000;
            //asd.LinkedElementsCount = 2000;
            //asd.GlobalSetup();
            //asd.For();
        }
    }
}
