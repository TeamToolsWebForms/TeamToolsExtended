using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class UserLogoId_Should
    {
        [TestCase(15)]
        [TestCase(11777)]
        public void SetUserLogoId_Correct(int id)
        {
            var user = new User();

            user.UserLogoId = id;

            Assert.AreEqual(id, user.UserLogoId);
        }
    }
}
