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
            Add(MemoryDiagnoser.Default);

            Job job1 = Job.Default
                .With(CsProjCoreToolchain.NetCoreApp31)
                .With(Platform.X64)
                .WithLaunchCount(2)
                .WithIterationCount(3)
                .WithWarmupCount(1);

            Add(job1);

            Job job2 = Job.Default
                .With(CsProjCoreToolchain.NetCoreApp22)
                .With(Platform.X64)
                .WithLaunchCount(2)
                .WithIterationCount(3)
                .WithWarmupCount(1);

            Add(job2);
        }
    }
}
