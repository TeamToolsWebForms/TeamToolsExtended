using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Title_Should
    {
        [TestCase("ComeOn")]
        [TestCase("It's okay")]
        public void SetTitle_Correct(string title)
        {
            var project = new Project();

            project.Title = title;

            Assert.AreEqual(title, project.Title);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var project = new Project();

            var property = project.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var project = new Project();

            var property = project.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
