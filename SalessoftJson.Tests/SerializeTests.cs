using Newtonsoft.Json;
using Salessoft.Json;
using SalessoftJsonTests.Model;

namespace SalessoftJsonTests
{
    public class SerializeTests
    {
        public SerializeTests()
        {
            SuperJson.Setup((config) =>
            {
                config.AcceptComments()
                    .AutomaticallyMapObjects();

            });
        }

        [Trait("Category", "Serialize")]
        [Fact]
        public void Should_Serialize_When_UsingPrimitiveTypes()
        {
            Guid expectedGuid = Guid.NewGuid();
            DateTime expectedDateTime = DateTime.UtcNow;

            var testObject = new HelloWorld
            {
                Hello = "World",
                Boolean = true,
                BooleanNull = null,
                Integer16 = 1231,
                Integer32 = 221314324,
                Integer64 = -213127317823,
                Guid = expectedGuid,
                DateTime = expectedDateTime,
            };

            var testObject2 = new HelloWorld
            {
                Hello = "World",
                Boolean = true,
                BooleanNull = null,
                Integer16 = 1231,
                Integer32 = 221314324,
                Integer64 = -213127317823,
                Guid = expectedGuid,
                DateTime = expectedDateTime,
                SubObject = testObject
            };

            // yes I dare
            string expected = JsonConvert.SerializeObject(testObject);
            string actual = SuperJson.Serialize(testObject);
            Assert.Equal(expected, actual);

            string expectedSub = JsonConvert.SerializeObject(testObject2);
            string actualSub = SuperJson.Serialize(testObject2);
            Assert.Equal(expectedSub, actualSub);
        }
    }
}
