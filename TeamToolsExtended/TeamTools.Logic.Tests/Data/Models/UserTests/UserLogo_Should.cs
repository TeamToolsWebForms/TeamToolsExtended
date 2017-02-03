using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class UserLogo_Should
    {
        [Test]
        public void SetUserLogo_Correct()
        {
            var userLogo = new Mock<UserLogo>();
            var user = new User();

            user.UserLogo = userLogo.Object;

            Assert.AreSame(userLogo.Object, user.UserLogo);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("UserLogo").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
