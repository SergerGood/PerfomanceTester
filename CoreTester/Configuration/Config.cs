using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using Core;

namespace TypeTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(MemoryDiagnoser.Default);

            //Job clr471Job = Configurator.GetColdStartClr471Job();
            //Job clr472Job = Configurator.GetColdStartClr472Job();
            //Job core20Job = Configurator.GetColdStartCore20Job();
            Job core21Job = Configurator.GetColdStartCore22Job();

            Add(core21Job);
        }
    }
}
