using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models.Tests.UserTests
{
    [TestFixture]
    public class LastName_Should
    {
        [TestCase("John")]
        [TestCase("Smith")]
        public void SetLastName_Correct(string lastName)
        {
            var user = new User();

            user.LastName = lastName;

            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var user = new User();

            var property = user.GetType().GetProperty("LastName");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var user = new User();

            var property = user.GetType().GetProperty("LastName");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
