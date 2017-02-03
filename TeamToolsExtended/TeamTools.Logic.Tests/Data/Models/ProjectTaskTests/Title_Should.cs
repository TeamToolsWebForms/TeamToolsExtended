using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class Title_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetTile_Correct(string title)
        {
            var projectTask = new ProjectTask();

            projectTask.Title = title;

            Assert.AreEqual(title, projectTask.Title);
        }

        [Test]
        public void HaveRequired_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveIndex_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(IndexAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
