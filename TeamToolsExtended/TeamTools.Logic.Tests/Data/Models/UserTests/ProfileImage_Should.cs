using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class ProfileImage_Should
    {
        [Test]
        public void SetProfileImage_Correct()
        {
            var userLogo = new Mock<UserLogo>();
            var user = new User();

            user.ProfileImage = userLogo.Object;

            Assert.AreSame(userLogo.Object, user.ProfileImage);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("ProfileImage").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
