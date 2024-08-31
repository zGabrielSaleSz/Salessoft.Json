namespace Salessoft.Json
{
    public interface ISuperJsonSetup
    {
        bool SetupAcceptComments { get; }
        bool SetupAutomaticallyMapObjects { get; }

        ISuperJsonSetup AcceptComments(bool enable = true);
        ISuperJsonSetup AutomaticallyMapObjects(bool enable = true);

    }
}
