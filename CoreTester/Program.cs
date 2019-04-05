using System;
using BenchmarkDotNet.Running;
using TypeTester.Benchmarks;

namespace TypeTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(CreateCollectionsBenchmark),
                typeof(UseCollectionsBenchmark),
                typeof(CopyBenchmark),
                typeof(CopyWithUseBenchmark)
            });

            switcher.Run(args);

            //var asd = new CreateCollectionsBenchmark();
            //asd.GlobalSetup();
            //asd.CreateArrayOfStructs();
        }
    }
}
