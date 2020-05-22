using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AsyncEnumerableTester.Configuration;
using BenchmarkDotNet.Attributes;

namespace AsyncEnumerableTester.Benchmarks
{
    [Config(typeof(Config))]
    public class Benchmark
    {
        private static readonly HttpClient httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:3333") };

        [Benchmark]
        public async Task<List<Item>> GetListAsync()
        {
            var result = new List<Item>();
            foreach (var item in await GetAsync<IEnumerable<Item>>("item/1"))
            {
                result.Add(item);
            }

            return result;
        }

        [Benchmark]
        public async Task<List<Item>> GetEnumerableAsync()
        {
            var result = new List<Item>();
            foreach (var item in await GetAsync<IEnumerable<Item>>("item/2"))
            {
                result.Add(item);
            }

            return result;
        }

        [Benchmark]
        public async Task<List<Item>> GetAsyncEnumerableAsync()
        {
            var result = new List<Item>();
            foreach(var item in await GetAsync<IEnumerable<Item>>("item/3"))
            {
                result.Add(item);
            }

            return result;
        }

        private async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        //[Benchmark]
        //public List<string> Linq()
        //{
        //    var result = new List<string>();

        //    foreach (IEnumerable<string> files in LoadFiles().Where(x => x.Contains("Server")))
        //    {
        //        foreach (string file in files)
        //        {
        //            result.Add(file);
        //        }
        //    }

        //    return result;
        //}

        //[Benchmark]
        //public async Task<List<string>> LinqAsync()
        //{
        //    var result = new List<string>();

        //    await foreach (IEnumerable<string> files in LoadFilesAsync().Where(x => x.Contains("Server")))
        //    {
        //        foreach (string file in files)
        //        {
        //            result.Add(file);
        //        }
        //    }

        //    return result;
        //}

        private static IEnumerable<IEnumerable<string>> LoadFiles()
        {
            IEnumerable<string> directories = Directory.EnumerateDirectories(@"c:\1");

            foreach (string directory in directories)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(directory);
                yield return files;
            }
        }

        private static async IAsyncEnumerable<IEnumerable<string>> LoadFilesAsync()
        {
            IEnumerable<string> directories = Directory.EnumerateDirectories(@"c:\1");

            foreach (string directory in directories)
            {
                IEnumerable<string> files = await Task.Run(() => Directory.EnumerateFiles(directory));
                yield return files;
            }
        }
    }
}
