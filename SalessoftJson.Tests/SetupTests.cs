using Salessoft.Json.Domain.Exceptions;
using SuperJson = Salessoft.Json.SuperJson;

namespace SalessoftJsonTests 
{
    public class SetupTests
    {
        [Fact]
        [Trait("Category", "Setup")]
        public void Should_ThrownException_When_DoubleSetup()
        {
            SuperJson.Setup(s =>
            {
                s.AutomaticallyMapObjects(true);
                s.AcceptComments(true);
            });

            Assert.Throws<SetupAlreadyDoneException>(() =>
            {
                SuperJson.Setup(s =>
                {
                    s.AutomaticallyMapObjects(false);
                    s.AcceptComments(true);
                });
            });
        }

    }
}