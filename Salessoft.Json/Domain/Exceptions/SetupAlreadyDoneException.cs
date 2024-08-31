namespace Salessoft.Json.Domain.Exceptions
{
    public class SetupAlreadyDoneException : SuperJsonException
    {
        public SetupAlreadyDoneException() : base("Setup done previously")
        {
        }
    }
}
