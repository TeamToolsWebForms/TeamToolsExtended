using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class Project_Should
    {
        [Test]
        public void SetProject_Correct()
        {
            var project = new Mock<Project>();
            var doc = new ProjectDocument();

            doc.Project = project.Object;

            Assert.AreSame(project.Object, doc.Project);
        }

        [Test]
        public void BeVirtual()
        {
            var doc = new ProjectDocument();

            bool isVirtual = doc.GetType().GetProperty("Project").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
