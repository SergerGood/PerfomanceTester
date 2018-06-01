using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using CoreTester.Configuration;

namespace CoreTester.Benchmarks
{
    [Config(typeof(Config))]
    public class UseCollectionsBenchmark
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
        public IEnumerable<PointClass> WhereArrayOfClasses()
        {
            return arrayOfClasses
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
        }

        [Benchmark]
        public IEnumerable<PointStruct> WhereArrayOfStructs()
        {
            return arrayOfStructs
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
        }

        [Benchmark]
        public IEnumerable<PointReadonlyStruct> WhereArrayOfReadonlyStructs()
        {
            return arrayOfReadonlyStructs
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
        }

        [Benchmark]
        public IEnumerable<PointClass> WhereListOfClasses()
        {
            return listOfClasses
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
        }

        [Benchmark]
        public IEnumerable<PointStruct> WhereListOfStructs()
        {
            return listOfStructs
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
        }

        [Benchmark]
        public IEnumerable<PointReadonlyStruct> WhereListOfReadonlyStructs()
        {
            return listOfReadonlyStructs
                .Where(element => element.X > ElementsCount / 2)
                .Where(element => element.Y > ElementsCount / 2)
                .ToList();
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

            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfClasses[i] = new PointClass(i, i);
            }

            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfStructs[i] = new PointStruct(i, i);
            }

            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfReadonlyStructs[i] = new PointReadonlyStruct(i, i);
            }

            for (int i = 0; i < ElementsCount; i++)
            {
                listOfClasses.Add(new PointClass(i, i));
            }

            for (int i = 0; i < ElementsCount; i++)
            {
                listOfStructs.Add(new PointStruct(i, i));
            }

            for (int i = 0; i < ElementsCount; i++)
            {
                listOfReadonlyStructs.Add(new PointReadonlyStruct(i, i));
            }
        }
    }
}
