using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples
{
    public class ToListTest
    {
        public class PoolingVsAllocationBenchmark
        {
            //[Params(20, 100, 1000, 10000, 100000)]
            //public int N;

            //readonly int Min = 0;
            //readonly int Max = 20;

            //private List<int> items;
            //private List<int> searchItems;

            //[GlobalSetup]
            //public void GlobalSetup()
            //{
            //    items = new List<int>();
            //    searchItems = new List<int>();

            //    Random random = new Random();

            //    items.AddRange(Enumerable.Repeat(0, N).Select(i => random.Next(Min, Max)));
            //    searchItems.AddRange(Enumerable.Repeat(0, N).Select(i => random.Next(Min, Max)));
            //}

            //[Benchmark]
            //public int a()
            //{
            //    var enumerable = items.Where(x => searchItems.Contains(x)).ToList();

            //    return enumerable.Count(x => x == 2);
            //}

            //[Benchmark]
            //public int b()
            //{
            //    var enumerable = items.Where(x => searchItems.Contains(x));

            //    return enumerable.Count(x => x == 2);
            //}

            //[Benchmark]
            //public int c()
            //{

            //    return items.Count(x => searchItems.Contains(x) && x == 2);
            //}
        }
    }
}
