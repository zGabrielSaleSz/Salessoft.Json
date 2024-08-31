using Salessoft.Json.Domain;
using Salessoft.Json.Domain.Constants;
using Salessoft.Json.Domain.Exceptions;
using Salessoft.Json.Domain.Mapping;
using Salessoft.Json.Domain.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Salessoft.Json.Implementation
{
    internal class SuperJsonSerializer : ISuperJsonSerializer
    {
        private static IFormatProvider FormatProvider = CultureInfo.InvariantCulture;
        private readonly IMappingManager _mappingManager;
        private static readonly Dictionary<Type, Func<object, string>> _methodCache = new Dictionary<Type, Func<object, string>>()
        {
            { typeof(int), obj => Evaluate((int)obj) },
            { typeof(string), obj => Evaluate((string)obj) },
            { typeof(double), obj => Evaluate((double)obj) },
            { typeof(bool), obj => Evaluate((bool)obj) },
            { typeof(DateTime), obj => Evaluate((DateTime)obj) },
            { typeof(long), obj => Evaluate((long)obj) },
            { typeof(float), obj => Evaluate((float)obj) },
            { typeof(decimal), obj => Evaluate((decimal)obj) },
            { typeof(char), obj => Evaluate((char)obj) },
            { typeof(byte), obj => Evaluate((byte)obj) },
            { typeof(sbyte), obj => Evaluate((sbyte)obj) },
            { typeof(short), obj => Evaluate((short)obj) },
            { typeof(ushort), obj => Evaluate((ushort)obj) },
            { typeof(uint), obj => Evaluate((uint)obj) },
            { typeof(ulong), obj => Evaluate((ulong)obj) },
            { typeof(TimeSpan), obj => Evaluate((TimeSpan)obj) },
            { typeof(Guid), obj => Evaluate((Guid)obj) },
        };

        public SuperJsonSerializer(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;
        }

        public string Serialize(object item)
        {
            return Serialize(item, item.GetType());
        }

        public string Serialize(object item, Type type)
        {
            var objectMapper = _mappingManager.MapObject(type);
            StringBuilder sb = new StringBuilder();
            sb.Append(SuperJsonConstants.OpenCurlyBrackets);
            foreach (string key in objectMapper.Keys)
            {
                sb.Append(SuperJsonConstants.DoubleQuote);
                sb.Append(key);
                sb.Append(SuperJsonConstants.DoubleQuote);
                sb.Append(SuperJsonConstants.Colon);

                var property = objectMapper.GetAttribute(key);
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(item);

                sb.Append(Evaluate(propertyType, propertyValue));
                sb.Append(SuperJsonConstants.Comma);
            }
            // remove last comma 
            sb.Remove(sb.Length - 1, 1);
            sb.Append(SuperJsonConstants.CloseCurlyBrackets);
            return sb.ToString();
        }

        public string Evaluate(Type type, object param)
        {
            if (param == null)
            {
                return "null";
            }

            if (_methodCache.TryGetValue(type, out var evaluator))
            {
                return evaluator(param);
            }

            if (IsNullable(type))
            {
                return Evaluate(Nullable.GetUnderlyingType(type), param);
            }

            if (IsRealClass(type))
            {
                return Serialize(param);
            }

            throw new InvalidTypeException($"Handler not found for type {param.GetType()}");
        }

        private static bool IsRealClass(Type type)
        {
            return type.IsClass && type != typeof(string) && !type.IsPrimitive && !type.IsValueType;
        }

        private static bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static string Evaluate(int param)
        {
            return param.ToString();
        }

        private static string Evaluate(string param)
        {
            return $"{SuperJsonConstants.DoubleQuote}{param}{SuperJsonConstants.DoubleQuote}";
        }

        private static string Evaluate(double param)
        {
            return param.ToString(SuperJsonConstants.DECIMAL_FORMAT, FormatProvider);
        }

        private static string Evaluate(bool param)
        {
            switch (param)
            {
                case true:
                    return "true";
                case false:
                    return "false";
                default:
                    return "null";
            }
        }

        private static string Evaluate(DateTime param)
        {
            return $"{SuperJsonConstants.DoubleQuote}{param.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFZ")}{SuperJsonConstants.DoubleQuote}";
        }

        private static string Evaluate(long param)
        {
            return param.ToString();
        }

        private static string Evaluate(float param)
        {
            return param.ToString(SuperJsonConstants.DECIMAL_FORMAT, FormatProvider);
        }

        private static string Evaluate(decimal param)
        {
            return param.ToString(SuperJsonConstants.DECIMAL_FORMAT, FormatProvider);
        }

        private static string Evaluate(char param)
        {
            return param.ToString();
        }

        private static string Evaluate(byte param)
        {
            return param.ToString();
        }

        private static string Evaluate(sbyte param)
        {
            return param.ToString();
        }

        private static string Evaluate(short param)
        {
            return param.ToString();
        }

        private static string Evaluate(ushort param)
        {
            return param.ToString();
        }

        private static string Evaluate(uint param)
        {
            return param.ToString();
        }

        private static string Evaluate(ulong param)
        {
            return param.ToString();
        }

        private static string Evaluate(TimeSpan param)
        {
            // no idea
            return $"{SuperJsonConstants.DoubleQuote}{param}{SuperJsonConstants.DoubleQuote}";
        }

        private static string Evaluate(Guid param)
        {
            return $"{SuperJsonConstants.DoubleQuote}{param}{SuperJsonConstants.DoubleQuote}";
        }
    }
}
