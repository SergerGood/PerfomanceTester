using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using Core;

namespace TypeTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Configurator.GetDefaultCore80Job());
        }
    }
}
