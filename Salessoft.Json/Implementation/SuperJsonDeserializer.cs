using Salessoft.Json.Domain;
using Salessoft.Json.Domain.Mapping;

namespace Salessoft.Json.Implementation
{
    public class SuperJsonDeserializer : ISuperJsonDeserializer
    {
        private IMappingManager _mappingManager;

        public SuperJsonDeserializer(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;
        }

        public T Deserialize<T>(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}
