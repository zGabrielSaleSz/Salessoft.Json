using Salessoft.Json.Domain.Exceptions;
using System;

namespace Salessoft.Json.Domain.Tools
{
    public class SuperJsonValidator
    {
        public static void NotNull(object @object, string argname)
        {
            if (@object == null)
            {
                throw new SuperJsonException($"{argname} is null");
            }
        }
    }
}
