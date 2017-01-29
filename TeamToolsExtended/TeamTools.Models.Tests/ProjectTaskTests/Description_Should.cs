using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class Description_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetDescription_Correct(string description)
        {
            var projectTask = new ProjectTask();

            projectTask.Description = description;

            Assert.AreEqual(description, projectTask.Description);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Description");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
