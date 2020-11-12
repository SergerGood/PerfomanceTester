using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using Core;

namespace ArrayPoolTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddDiagnoser(MemoryDiagnoser.Default);

            Job newJob = Configurator.GetDefaultCore50Job();

            AddJob(newJob);
        }
    }
}
