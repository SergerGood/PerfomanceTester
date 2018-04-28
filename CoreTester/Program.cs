using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace CoreTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var typeMemoryTester = new TypeMemoryBenchmark();
            typeMemoryTester.GlobalSetup();
            typeMemoryTester.CreateCollectionOfStructs();

            var summary = BenchmarkRunner.Run<TypeMemoryBenchmark>();
        }
    }
}
