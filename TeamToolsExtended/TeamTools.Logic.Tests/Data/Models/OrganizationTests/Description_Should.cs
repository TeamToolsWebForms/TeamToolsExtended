using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class Description_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetDescription_Correct(string description)
        {
            var organization = new Organization();

            organization.Description = description;

            Assert.AreEqual(description, organization.Description);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
