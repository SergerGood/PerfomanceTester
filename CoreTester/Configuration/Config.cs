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

            //Job clr471Job = Configurator.GetColdStartClr471Job();
            //Job clr472Job = Configurator.GetColdStartClr472Job();
            //Job core20Job = Configurator.GetColdStartCore20Job();

            AddJob(Configurator.GetDefaultCore31Job());
        }
    }
}
