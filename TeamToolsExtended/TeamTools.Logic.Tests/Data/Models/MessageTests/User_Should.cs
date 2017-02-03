using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            var creator = new Mock<User>();
            var message = new Message();

            message.User = creator.Object;

            Assert.AreSame(creator.Object, message.User);
        }

        [Test]
        public void BeVirtual()
        {
            var message = new Message();

            bool isVirtual = message.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
