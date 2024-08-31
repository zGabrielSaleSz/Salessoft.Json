using System;

namespace Salessoft.Json.Domain.Properties
{
    public class SuperJsonMapAttribute : Attribute
    {
        public string AttributeName { get; private set; }
        public SuperJsonMapAttribute(string attributeName) {
            AttributeName = attributeName;
        }
    }
}
