using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;
using TypeTester.Configuration;

namespace TypeTester.Benchmarks
{
    [Config(typeof(Config))]
    public class UseCollectionsBenchmark
    {
        private PointClass[] arrayOfClasses;
        private PointStruct[] arrayOfStructs;
        private PointReadonlyStruct[] arrayOfReadonlyStructs;
        private PersonRecord[] arrayOfRecords;

        private List<PointClass> listOfClasses;
        private List<PointStruct> listOfStructs;
        private List<PointReadonlyStruct> listOfReadonlyStructs;
        private List<PersonRecord> listOfRecords;

        private ImmutableArray<PointStruct> immutableArrayOfStructs;

        [Params(1_000)]
        public int ElementsCount { get; set; }

        [Benchmark]
        public bool WhereArrayOfClasses()
        {
            var element = new PointClass(ElementsCount, ElementsCount);
            var result = arrayOfClasses.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereArrayOfStructs()
        {
            var element = new PointStruct(ElementsCount, ElementsCount);
            var result = arrayOfStructs.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereArrayOfReadonlyStructs()
        {
            var element = new PointReadonlyStruct(ElementsCount, ElementsCount);
            var result = arrayOfReadonlyStructs.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereArrayOfRecords()
        {
            var element = new PersonRecord { X = ElementsCount, Y = ElementsCount };
            var result = arrayOfRecords.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereListOfClasses()
        {
            var element = new PointClass(ElementsCount, ElementsCount);
            var result = listOfClasses.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereListOfStructs()
        {
            var element = new PointStruct(ElementsCount, ElementsCount);
            var result = listOfStructs.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereListOfReadonlyStructs()
        {
            var element = new PointReadonlyStruct(ElementsCount, ElementsCount);
            var result = listOfReadonlyStructs.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereImmutableArrayOfStructs()
        {
            var element = new PointStruct(ElementsCount, ElementsCount);
            var result = immutableArrayOfStructs.Contains(element);

            return result;
        }

        [Benchmark]
        public bool WhereListOfRecords()
        {
            var element = new PersonRecord { X = ElementsCount, Y = ElementsCount };
            var result = listOfRecords.Contains(element);

            return result;
        }


        [GlobalSetup]
        public void GlobalSetup()
        {
            arrayOfClasses = new PointClass[ElementsCount];
            arrayOfStructs = new PointStruct[ElementsCount];
            arrayOfReadonlyStructs = new PointReadonlyStruct[ElementsCount];
            arrayOfRecords = new PersonRecord[ElementsCount];

            listOfClasses = new List<PointClass>(ElementsCount);
            listOfStructs = new List<PointStruct>(ElementsCount);
            listOfReadonlyStructs = new List<PointReadonlyStruct>(ElementsCount);
            listOfRecords = new List<PersonRecord>(ElementsCount);

            for (int i = 0; i < ElementsCount; i++)
            {
                arrayOfClasses[i] = new PointClass(i, i);
                arrayOfStructs[i] = new PointStruct(i, i);
                arrayOfReadonlyStructs[i] = new PointReadonlyStruct(i, i);
                arrayOfRecords[i] = new PersonRecord { X = i, Y = i };

                listOfClasses.Add(new PointClass(i, i));
                listOfStructs.Add(new PointStruct(i, i));
                listOfReadonlyStructs.Add(new PointReadonlyStruct(i, i));
                listOfRecords.Add(new PersonRecord { X = i, Y = i });

                immutableArrayOfStructs = ImmutableArray.CreateRange(arrayOfStructs);
            }
        }
    }
}
