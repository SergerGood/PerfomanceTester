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

            Job core22Job = Configurator.GetColdStartCore22Job();

            Add(core22Job);
        }
    }
}
