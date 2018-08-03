using System;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Core
{
    public static class Configurator
    {
        public static Job GetColdStartClr471Job()
        {
            return Job.Clr
                .With(CsProjClassicNetToolchain.Net471)
                .WithColdStartJob();
        }

        public static Job GetColdStartClr472Job()
        {
            return Job.Clr
                .With(CsProjClassicNetToolchain.Net472)
                .WithColdStartJob();
        }

        public static Job GetColdStartCore20Job()
        {
            return Job.Clr
                .With(CsProjCoreToolchain.NetCoreApp20)
                .WithColdStartJob();
        }

        public static Job GetColdStartCore21Job()
        {
            return Job.Clr
                .With(CsProjCoreToolchain.NetCoreApp21)
                .WithColdStartJob();
        }

        public static Job GetDefaultClr471Job()
        {
            return Job.Clr
                .With(CsProjClassicNetToolchain.Net471)
                .WithDefaultJob();
        }

        public static Job GetDefaultClr472Job()
        {
            return Job.Clr
                .With(CsProjClassicNetToolchain.Net472)
                .WithDefaultJob();
        }

        public static Job GetDefaultCore20Job()
        {
            return Job.Clr
                .With(CsProjCoreToolchain.NetCoreApp20)
                .WithDefaultJob();
        }

        public static Job GetDefaultCore21Job()
        {
            return Job.Clr
                .With(CsProjCoreToolchain.NetCoreApp21)
                .WithDefaultJob();
        }
    }
}
