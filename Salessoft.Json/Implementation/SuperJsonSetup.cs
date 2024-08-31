using Salessoft.Json.Domain.Mapping;

namespace Salessoft.Json.Implementation
{
    public class SuperJsonSetup : ISuperJsonSetup
    {
        private readonly IMappingManager _mappingManager;

        public SuperJsonSetup()
        {
          
        }
        public bool SetupAcceptComments { get; private set; } = true;

        public bool SetupAutomaticallyMapObjects { get; private set; } = true;

        public ISuperJsonSetup AcceptComments(bool enable)
        {
            SetupAcceptComments = enable;
            return this;
        }

        public ISuperJsonSetup AutomaticallyMapObjects(bool enable)
        {
            SetupAutomaticallyMapObjects = enable;
            return this;
        }
    }
}
