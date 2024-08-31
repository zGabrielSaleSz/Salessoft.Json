namespace Salessoft.Json.Domain
{
    public interface ISuperJsonDeserializer
    {
        T Deserialize<T>(string json);
    }
}
