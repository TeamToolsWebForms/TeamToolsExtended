using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserLogoTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            var user = new Mock<User>();
            var userLogo = new UserLogo();

            userLogo.User = user.Object;

            Assert.AreSame(user.Object, userLogo.User);
        }

        [Test]
        public void BeVirtual()
        {
            var userLogo = new UserLogo();

            bool isVirtual = userLogo.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
