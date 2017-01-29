using NUnit.Framework;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class CreatorId_Should
    {
        [TestCase(1)]
        [TestCase(500)]
        public void SetCreatodId_Correct(int id)
        {
            var message = new Message();

            message.CreatorId = id;

            Assert.AreEqual(id, message.CreatorId);
        }
    }
}
