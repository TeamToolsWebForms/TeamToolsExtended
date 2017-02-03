using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Description_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetDescription_Correct(string description)
        {
            var project = new Project();

            project.Description = description;

            Assert.AreEqual(description, project.Description);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var project = new Project();

            var property = project.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var project = new Project();

            var property = project.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
