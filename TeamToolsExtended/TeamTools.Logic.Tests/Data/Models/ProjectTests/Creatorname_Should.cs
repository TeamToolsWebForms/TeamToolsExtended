using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Creatorname_Should
    {
        [TestCase("Okay")]
        [TestCase("MoreOkay")]
        public void SetCreatorName_Correct(string name)
        {
            var project = new Project();

            project.CreatorName = name;

            Assert.AreEqual(name, project.CreatorName);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var project = new Project();

            var property = project.GetType().GetProperty("CreatorName");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
