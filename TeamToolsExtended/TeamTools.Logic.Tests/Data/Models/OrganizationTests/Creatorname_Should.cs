using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class Creatorname_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetCreatorName_Correct(string name)
        {
            var organization = new Organization();

            organization.CreatorName = name;

            Assert.AreEqual(name, organization.CreatorName);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var organization = new Organization();

            var property = organization.GetType().GetProperty("CreatorName");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
