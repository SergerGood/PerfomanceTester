using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace ReadOnlyStructTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddDiagnoser(MemoryDiagnoser.Default);

            Job job1 = Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp80)
                .WithPlatform(Platform.X64)
                .WithLaunchCount(2)
                .WithIterationCount(3)
                .WithWarmupCount(1);

            AddJob(job1);
        }
    }
}
