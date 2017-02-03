using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserLogoTests
{
    [TestFixture]
    public class UserId_Should
    {
        [TestCase(15)]
        [TestCase(1)]
        public void SetUserId_Correct(int id)
        {
            var userLogo = new UserLogo();

            userLogo.UserId = id;

            Assert.AreEqual(id, userLogo.UserId);
        }
    }
}
