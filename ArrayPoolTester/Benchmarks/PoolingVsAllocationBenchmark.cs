using System;
using System.Buffers;
using ArrayPoolTester.Configuration;
using BenchmarkDotNet.Attributes;

namespace ArrayPoolTester.Benchmarks
{
    [Config(typeof(Config))]
    public class PoolingVsAllocationBenchmark
    {
        [Params(20, 100, 1000)]
        public int N;

        private readonly ArrayPool<byte> pool = ArrayPool<byte>.Shared;

        [Benchmark]
        public byte[] Allocate()
        {
            return new byte[N];
        }

        [Benchmark]
        public byte[] Rent()
        {
            byte[] rented = pool.Rent(N);
            pool.Return(rented);

            return rented;
        }
    }
}
