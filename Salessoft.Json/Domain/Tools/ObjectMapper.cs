using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Salessoft.Json.Domain.Tools
{
    public class ObjectMapper : IObjectMapper
    {
        public IList<string> Keys { get; private set; }
        private IDictionary<string, PropertyInfo> _propertyByKeys;
        public ObjectMapper(Type type)
        {
            Keys = new List<string>();
            _propertyByKeys = new ConcurrentDictionary<string, PropertyInfo>();
            foreach (var property in type.GetProperties())
            {
                Keys.Add(property.Name);
                _propertyByKeys.Add(property.Name, property);
            }
        }

        public PropertyInfo GetAttribute(string name)
        {
            return _propertyByKeys[name];
        }
    }
}
