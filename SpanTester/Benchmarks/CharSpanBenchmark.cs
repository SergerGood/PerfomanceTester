using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using SpanTester.Configuration;

namespace SpanTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CharSpanBenchmark
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
        public char Slice()
        {
            return text.AsSpan().Slice(0, text.Length / 2)[1];
        }

        [Benchmark]
        public char Substring()
        {
            return text.Substring(0, text.Length / 2)[1];
        }
    }
}
