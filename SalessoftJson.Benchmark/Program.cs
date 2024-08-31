using BenchmarkDotNet.Running;

namespace SalessoftJsonBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ObjectIsCheckVsDictionaryByCallback>();
        }
    }
}