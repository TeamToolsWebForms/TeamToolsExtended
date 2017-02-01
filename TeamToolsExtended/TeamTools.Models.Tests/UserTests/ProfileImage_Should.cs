using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models.Tests.UserTests
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

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var user = new User();

            var property = user.GetType().GetProperty("ProfileImage");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
