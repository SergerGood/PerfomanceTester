using System;
using BenchmarkDotNet.Running;
using CoreTester.Benchmarks;

namespace CoreTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //BenchmarkRunner.Run<TypeMemoryBenchmark>();
            //BenchmarkRunner.Run<CopyBenchmark>();
            BenchmarkRunner.Run<CopyWithUseBenchmark>();
        }
    }
}
