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
            Add(MemoryDiagnoser.Default);

            Job newJob = Configurator.GetDefaultCore31Job();

            Add(newJob);
        }
    }
}
