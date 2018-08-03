using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    public class CreateCollectionsBenchmark
    {
        private PointClass[] arrayOfClasses;
        private PointStruct[] arrayOfStructs;
        private PointReadonlyStruct[] arrayOfReadonlyStructs;

        private List<PointClass> listOfClasses;
        private List<PointStruct> listOfStructs;
        private List<PointReadonlyStruct> listOfReadonlyStructs;

        [Params(10_000_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public PointClass[] CreateArrayOfClasses()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfClasses[i] = new PointClass(i, i);
            }

            return arrayOfClasses;
        }

        [Benchmark]
        public PointStruct[] CreateArrayOfStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfStructs[i] = new PointStruct(i, i);
            }

            return arrayOfStructs;
        }

        [Benchmark]
        public PointReadonlyStruct[] CreateArrayOfReadonlyStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfReadonlyStructs[i] = new PointReadonlyStruct(i, i);
            }

            return arrayOfReadonlyStructs;
        }

        [Benchmark]
        public List<PointClass> CreateListOfClasses()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                listOfClasses.Add(new PointClass(i, i));
            }

            return listOfClasses;
        }

        [Benchmark]
        public List<PointStruct> CreateListOfStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                listOfStructs.Add(new PointStruct(i, i));
            }

            return listOfStructs;
        }

        [Benchmark]
        public List<PointReadonlyStruct> CreateListOfReadonlyStructs()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                listOfReadonlyStructs.Add(new PointReadonlyStruct(i, i));
            }

            return listOfReadonlyStructs;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            arrayOfClasses = new PointClass[ElementsCount];
            arrayOfStructs = new PointStruct[ElementsCount];
            arrayOfReadonlyStructs = new PointReadonlyStruct[ElementsCount];

            listOfClasses = new List<PointClass>(ElementsCount);
            listOfStructs = new List<PointStruct>(ElementsCount);
            listOfReadonlyStructs = new List<PointReadonlyStruct>(ElementsCount);
        }
    }
}
