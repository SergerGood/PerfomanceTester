using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace CoreTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(MemoryDiagnoser.Default);

            Job clr471Job = Job.Clr
                .With(CsProjClassicNetToolchain.Net471)
                .WithDefaultJob();

            Job coreJob = Job.Core
                .With(CsProjCoreToolchain.NetCoreApp20)
                .WithDefaultJob();

            Add(coreJob, clr471Job);
        }
    }
}
