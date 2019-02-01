using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using Core;

namespace ParallelTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(MemoryDiagnoser.Default);

            Job core21Job = Configurator.GetColdStartCore21Job();

            Add(core21Job);
        }
    }
}
