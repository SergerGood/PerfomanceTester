using System;
using BenchmarkDotNet.Running;
using ReadOnlyStructTester.Benchmarks;

namespace ReadOnlyStructTester
{
    class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(UnnecessaryCopyingBenchmark)
            });

            switcher.Run(args);


            //var benchmark = new UnnecessaryCopyingBenchmark { ElementsCount = 100 };
            //benchmark.Setup();
            //benchmark.ExtendedEquals();
        }
    }
}
