using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTools.Models.Tests.OrganizationTests
{
    [TestFixture]
    public class Name_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetName_Correct(string name)
        {
            var organization = new Organization();

            organization.Name = name;

            Assert.AreEqual(name, organization.Name);
        }

        [Test]
        public void HaveRequired_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Name");
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveIndex_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Name");
            bool isDefined = Attribute.IsDefined(property, typeof(IndexAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Name");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("Name");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
