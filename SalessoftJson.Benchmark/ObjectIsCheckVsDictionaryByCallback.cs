using BenchmarkDotNet.Attributes;

namespace SalessoftJsonBenchmark
{
    // to do
    public class ObjectIsCheckVsDictionaryByCallback
    {
        private Dictionary<string, Func<object, string>> callbacks = new Dictionary<string, Func<object, string>>();
        [GlobalSetup]
        public void Setup()
        {
            callbacks.Add("string", (o) => Handle((string)o));
        }

        [Benchmark]
        public void ObjectIsCheck()
        {

        }

        [Benchmark]
        public void DictionaryByCallback()
        {

        }

        private string Handle(string param)
        {
            return "string";
        }

        private string Handle(int param)
        {
            return "int";
        }

        private string Handle(long param)
        {
            return "long";
        }

        private string Handle(float param)
        {
            return "float";
        }

        private string Handle(double param)
        {
            return "double";
        }

        private string Handle(decimal param)
        {
            return "decimal";
        }

        private string Handle(bool param)
        {
            return "bool";
        }

        private string Handle(char param)
        {
            return "char";
        }

        private string Handle(byte param)
        {
            return "byte";
        }

        private string Handle(sbyte param)
        {
            return "sbyte";
        }

        private string Handle(short param)
        {
            return "short";
        }

        private string Handle(ushort param)
        {
            return "ushort";
        }

        private string Handle(uint param)
        {
            return "uint";
        }

        private string Handle(ulong param)
        {
            return "ulong";
        }

        private string Handle(object param)
        {
            return "object";
        }

        private string Handle(DateTime param)
        {
            return "DateTime";
        }

        private string Handle(TimeSpan param)
        {
            return "TimeSpan";
        }

        private string Handle(Guid param)
        {
            return "Guid";
        }

    }
}