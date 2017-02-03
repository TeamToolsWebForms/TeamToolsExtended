using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class ProfileImage_Should
    {
        [TestCase(new byte[] { 12, 15, 16 })]
        [TestCase(new byte[] { 12, 15, 16, 1, 1, 1, 1 })]
        public void SetProfileImage_Correct(byte[] array)
        {
            var user = new User();

            user.ProfileImage = array;

            Assert.AreEqual(array, user.ProfileImage);
        }
    }
}
