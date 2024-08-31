using Salessoft.Json.Domain;
using Salessoft.Json.Domain.Mapping;

namespace Salessoft.Json.Implementation
{
    public class SuperJsonDeserializerWithComments : ISuperJsonDeserializer
    {
        private IMappingManager _mappingManager;

        public SuperJsonDeserializerWithComments(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;
        }

        public T Deserialize<T>(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}
