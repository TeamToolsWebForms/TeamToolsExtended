using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models.Tests.UserTests
{
    [TestFixture]
    public class FirstName_Should
    {
        [TestCase("John")]
        [TestCase("Smith")]
        public void SetFirstName_Correct(string firstName)
        {
            var user = new User();

            user.FirstName = firstName;

            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var user = new User();

            var property = user.GetType().GetProperty("FirstName");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var user = new User();

            var property = user.GetType().GetProperty("FirstName");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
