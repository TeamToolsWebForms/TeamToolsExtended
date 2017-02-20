using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfProject_WithCorrectSetProperties()
        {
            string title = "Some title";
            string description = "some description";
            string username = "some username";

            var project = new Project(title, description, username);

            Assert.AreEqual(title, project.Title);
            Assert.AreEqual(description, project.Description);
            Assert.AreEqual(username, project.CreatorName);
            Assert.IsInstanceOf<Project>(project);
        }
    }
}
