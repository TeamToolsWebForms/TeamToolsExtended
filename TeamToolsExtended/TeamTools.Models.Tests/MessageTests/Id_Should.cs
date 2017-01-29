using NUnit.Framework;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(2)]
        public void SetId(int id)
        {
            var message = new Message();

            message.Id = id;

            Assert.AreEqual(id, message.Id);
        }
    }
}
