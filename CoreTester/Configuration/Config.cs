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

            //Job clr472Job = Job.Clr
            //    .With(CsProjClassicNetToolchain.Net472)
            //    .WithDefaultJob();

            Job core20Job = Job.Core
                .With(CsProjCoreToolchain.NetCoreApp20)
                .WithDefaultJob();

            Job core21Job = Job.Core
                .With(CsProjCoreToolchain.NetCoreApp21)
                .WithDefaultJob();

            Add(core20Job, core21Job, clr471Job);
        }
    }
}
