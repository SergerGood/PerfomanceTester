using System;
using BenchmarkDotNet.Running;

namespace CoreTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<TypeMemoryBenchmark>();
        }
    }
}
