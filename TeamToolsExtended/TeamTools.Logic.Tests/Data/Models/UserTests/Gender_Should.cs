using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class Gender_Should
    {
        [TestCase("SomeName")]
        [TestCase("OtherName")]
        public void SetGender_Correct(string gender)
        {
            var user = new User();

            user.Gender = gender;

            Assert.AreEqual(gender, user.Gender);
        }
    }
}
