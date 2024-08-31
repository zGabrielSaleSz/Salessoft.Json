using System;
using Salessoft.Json.Domain.Tools;

namespace Salessoft.Json.Domain.Mapping
{
    public interface IMappingManager
    {
        IObjectMapper MapObject(Type type);
    }
}
