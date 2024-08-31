using Salessoft.Json.Domain.Tools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Salessoft.Json.Domain.Mapping
{
    public class MappingManager : IMappingManager
    {
        private IDictionary<string, IObjectMapper> _mappedObjects;
        private readonly ISuperJsonSetup _setup;

        public MappingManager(ISuperJsonSetup superJsonSetup) 
        {
            _mappedObjects = new ConcurrentDictionary<string, IObjectMapper>();
            _setup = superJsonSetup;
        }

        public IObjectMapper MapObject(Type type)
        {
            string typeFullName = type.FullName;
            if (_setup.SetupAutomaticallyMapObjects)
            {
                if (_mappedObjects.TryGetValue(typeFullName, out var objectMapper))
                {
                    return objectMapper;
                }
                var newObjectMapper = new ObjectMapper(type);
                _mappedObjects.Add(typeFullName, newObjectMapper);
                return newObjectMapper;
            }
            return new ObjectMapper(type);
        }
    }
}
