using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class UserId_Should
    {
        [TestCase(1)]
        [TestCase(500)]
        public void SetUserId_Correct(int id)
        {
            var message = new Message();

            message.UserId = id;

            Assert.AreEqual(id, message.UserId);
        }
    }
}
