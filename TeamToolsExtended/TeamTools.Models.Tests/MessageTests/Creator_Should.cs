using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class Creator_Should
    {
        [Test]
        public void SetCreator_Correct()
        {
            var creator = new Mock<User>();
            var message = new Message();

            message.Creator = creator.Object;

            Assert.AreSame(creator.Object, message.Creator);
        }

        [Test]
        public void BeVirtual()
        {
            var message = new Message();

            bool isVirtual = message.GetType().GetProperty("Creator").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
