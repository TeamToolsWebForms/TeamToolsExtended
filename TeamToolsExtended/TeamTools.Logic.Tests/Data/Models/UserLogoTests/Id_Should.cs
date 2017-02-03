using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserLogoTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(15)]
        [TestCase(1200)]
        public void SetId_Correct(int id)
        {
            var userLogo = new UserLogo();

            userLogo.Id = id;

            Assert.AreEqual(id, userLogo.Id);
        }
    }
}
