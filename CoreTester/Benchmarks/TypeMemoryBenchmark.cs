using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester.Benchmarks
{
    [Config(typeof(Config))]
    public class TypeMemoryBenchmark
    {
        private PointClass[] arrayOfClasses;
        private PointStruct[] arrayOfStructs;

        private List<PointClass> listOfClasses;
        private List<PointStruct> listOfStructs;

        [Params(10_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass[] CreateArrayOfClasses()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfClasses[i] = new PointClass { X = i, Y = i };
            }

            return arrayOfClasses;
        }

        [Benchmark]
        public PointStruct[] CreateArrayOfStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfStructs[i] = new PointStruct { X = i, Y = i };
            }

            return arrayOfStructs;
        }

        [Benchmark]
        public List<PointClass> CreateListOfClasses()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                listOfClasses.Add(new PointClass { X = i, Y = i });
            }

            return listOfClasses;
        }

        [Benchmark]
        public List<PointStruct> CreateListOfStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                listOfStructs.Add(new PointStruct { X = i, Y = i });
            }

            return listOfStructs;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            arrayOfClasses = new PointClass[ElementsCount];
            arrayOfStructs = new PointStruct[ElementsCount];
            listOfClasses = new List<PointClass>(ElementsCount);
            listOfStructs = new List<PointStruct>(ElementsCount);
        }
    }
}
