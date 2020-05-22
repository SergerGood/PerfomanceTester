using System;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Core
{
    public static class Configurator
    {
        public static Job GetColdStartClr471Job()
        {
            return Job.Default
                .WithToolchain(CsProjClassicNetToolchain.Net471)
                .WithColdStartJob();
        }

        public static Job GetColdStartClr472Job()
        {
            return Job.Default
                .WithToolchain(CsProjClassicNetToolchain.Net472)
                .WithPlatform(Platform.X64)
                .WithLaunchCount(3)
                .WithIterationCount(5)
                .WithWarmupCount(3);
        }

        public static Job GetColdStartCore20Job()
        {
            return Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp20)
                .WithColdStartJob();
        }

        public static Job GetColdStartCore22Job()
        {
            return Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp22)
                .WithPlatform(Platform.X64)
                .WithLaunchCount(2)
                .WithIterationCount(4)
                .WithWarmupCount(2);
        }

        public static Job GetDefaultClr471Job()
        {
            return Job.Default
                .WithToolchain(CsProjClassicNetToolchain.Net471)
                .WithDefaultJob();
        }

        public static Job GetDefaultClr472Job()
        {
            return Job.Default
                .WithToolchain(CsProjClassicNetToolchain.Net472)
                .WithDefaultJob();
        }

        public static Job GetDefaultCore20Job()
        {
            return Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp20)
                .WithDefaultJob();
        }

        public static Job GetDefaultCore21Job()
        {
            return Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp21)
                .WithDefaultJob();
        }

        public static Job GetDefaultCore31Job()
        {
            return Job.Default
                .WithToolchain(CsProjCoreToolchain.NetCoreApp31)
                .WithDefaultJob();
        }
    }
}
