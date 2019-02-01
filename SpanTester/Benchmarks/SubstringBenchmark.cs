using System;
using System.Buffers.Text;
using System.Linq;
using BenchmarkDotNet.Attributes;
using SpanTester.Configuration;

namespace SpanTester.Benchmarks
{
    [Config(typeof(Config))]
    public class SubstringBenchmark
    {
        private string text;

        [Params(10, 100, 1000)]
        public int CharactersCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            text = new string(Enumerable.Repeat('a', CharactersCount).ToArray());
            text = "content-length:" + text;
        }

        [Benchmark]
        public int Slice()
        {
            return int.Parse(text.AsSpan().Slice(15));
        }

        [Benchmark]
        public int Substring()
        {
            return int.Parse(text.Substring(15)); 
        }
    }
}
