using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using SpanTester.Configuration;

namespace SpanTester.Benchmarks
{
    [Config(typeof(Config))]
    public class SpanBenchmark
    {
        private string text;

        [Params(10, 100, 1000)]
        public int CharactersCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            text = new string(Enumerable.Repeat('a', CharactersCount).ToArray());
        }

        [Benchmark]
        public string Substring()
        {
            return text.Substring(0, text.Length / 2);
        }

        [Benchmark]
        public string Slice()
        {
            return text.AsSpan().Slice(0, text.Length / 2).ToString();
        }
    }
}
