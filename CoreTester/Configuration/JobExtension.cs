using System;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace CoreTester.Configuration
{
    public static class JobExtension
    {
        public static Job WithDefaultJob(this Job job)
        {
            return job.With(RunStrategy.ColdStart)
                .With(Platform.X64)
                .WithLaunchCount(1)
                .WithTargetCount(5)
                .WithWarmupCount(1);
        }
    }
}
