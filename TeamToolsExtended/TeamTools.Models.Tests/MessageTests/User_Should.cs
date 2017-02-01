using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.MessageTests
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
