using System.Collections.Generic;
using System.Reflection;

namespace Salessoft.Json.Domain.Tools
{
    public interface IObjectMapper
    {
        IList<string> Keys { get; }

        PropertyInfo GetAttribute(string name);
    }
}
