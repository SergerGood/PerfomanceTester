using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Reports;
using Core;

namespace TypeTester.Configuration

{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Configurator.GetDefaultCore80Job());

            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}
