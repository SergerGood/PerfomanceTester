using System;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace Core
{
    public static class JobExtension
    {
        public static Job WithColdStartJob(this Job job)
        {
            return job.WithColdStartJob()
                .WithPlatform(Platform.X64)
                .WithLaunchCount(1)
                .WithIterationCount(3)
                .WithWarmupCount(0);
        }

        public static Job WithDefaultJob(this Job job)
        {
            return job
                .WithPlatform(Platform.X64)
                .WithLaunchCount(1)
                .WithIterationCount(3)
                .WithWarmupCount(0);
        }
    }
}
