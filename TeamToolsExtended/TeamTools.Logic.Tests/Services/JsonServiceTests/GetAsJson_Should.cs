using NUnit.Framework;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.JsonServiceTests
{
    [TestFixture]
    public class GetAsJson_Should
    {
        [Test]
        public void ReturnObjectAsString()
        {
            string expected = "{\"Name\":\"Some\",\"Age\":10}";
            var jsonService = new JsonService();
            var obj = new { Name = "Some", Age = 10 };

            var result = jsonService.GetAsJson(obj);

            Assert.AreEqual(expected, result);
        }
    }
}
