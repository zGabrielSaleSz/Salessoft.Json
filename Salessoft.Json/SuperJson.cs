
using Salessoft.Json.Domain;
using Salessoft.Json.Domain.Exceptions;
using Salessoft.Json.Domain.Mapping;
using Salessoft.Json.Implementation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Salessoft.Json
{
    public static class SuperJson
    {
        private static bool _setupReady;
        private static ISuperJsonSetup _setup;
        private static IMappingManager _mappingManager;
        private static ISuperJsonSerializer _superJsonSerializer;
        private static ISuperJsonDeserializer _superJsonDeserializer;

        static SuperJson()
        {
            _setup = new SuperJsonSetup();
            _mappingManager = new MappingManager(_setup);
            _setupReady = false;
        }

        public static void Setup(Action<ISuperJsonSetup> setupCallback)
        {
            if (_setupReady == true)
            {
                throw new SetupAlreadyDoneException();
            }
            setupCallback.Invoke(_setup);
            InternalSetup();
        }

        private static void InternalSetup()
        {
            // initilize implementations based in config to prevent if's
            _superJsonSerializer = new SuperJsonSerializer(_mappingManager);
            if (_setup.SetupAcceptComments)
            {
                _superJsonDeserializer = new SuperJsonDeserializerWithComments(_mappingManager);
            } 
            else
            {
                _superJsonDeserializer = new SuperJsonDeserializer(_mappingManager);
            }
            _setupReady = true;
        }

        public static string Serialize<T>(T obj)
        {
            EnsureSetupReady();
            return _superJsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            EnsureSetupReady();
            throw new NotImplementedException();
        }

        private static void EnsureSetupReady()
        {
            if (!_setupReady)
            {
                InternalSetup();
            }
        }
    }
}
