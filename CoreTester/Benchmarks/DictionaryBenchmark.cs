using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class DictionaryBenchmark
    {
        private Dictionary<PointClass, PointClass> dictionaty;
        private ReadOnlyDictionary<PointClass, PointClass> readOnlyDictionaty;
        private FrozenDictionary<PointClass, PointClass> frozenDictionary;
        private ImmutableDictionary<PointClass, PointClass> immutableDictionary;

        private PointClass searchElement;

        [Params(10, 1_000)]
        public int ElementsCount { get; set; }

        [Benchmark(Baseline = true), BenchmarkCategory("ContainsKey")]
        public bool DictionaryContainsKey() => dictionaty.ContainsKey(searchElement);

        [Benchmark, BenchmarkCategory("ContainsKey")]
        public bool ReadOnlyDictionaryContainsKey() => readOnlyDictionaty.ContainsKey(searchElement);

        [Benchmark, BenchmarkCategory("ContainsKey")]
        public bool FrozenDictionaryContainsKey() => frozenDictionary.ContainsKey(searchElement);

        [Benchmark, BenchmarkCategory("ContainsKey")]
        public bool ImmutableDictionaryContainsKey() => immutableDictionary.ContainsKey(searchElement);

        [Benchmark(Baseline = true), BenchmarkCategory("Construct")]
        public Dictionary<PointClass, PointClass> ConstructDictionary() => new(dictionaty);

        [Benchmark, BenchmarkCategory("Construct")]
        public ReadOnlyDictionary<PointClass, PointClass> ConstructReadOnlyDictionary() => dictionaty.AsReadOnly();

        [Benchmark, BenchmarkCategory("Construct")]
        public ImmutableDictionary<PointClass, PointClass> ConstructImmutableDictionary() => dictionaty.ToImmutableDictionary();

        [Benchmark, BenchmarkCategory("Construct")]
        public FrozenDictionary<PointClass, PointClass> ConstructFrozenDictionary() => dictionaty.ToFrozenDictionary();


        [GlobalSetup]
        public void GlobalSetup()
        {
            dictionaty = Enumerable.Range(0, ElementsCount)
                .Select(i => new PointClass(i, i))
                .ToDictionary(x => x, x => x);

            readOnlyDictionaty = dictionaty.AsReadOnly();
            immutableDictionary = dictionaty.ToImmutableDictionary();
            frozenDictionary = dictionaty.ToFrozenDictionary();

            searchElement = new PointClass(ElementsCount / 2, ElementsCount / 2);
        }
    }
}
