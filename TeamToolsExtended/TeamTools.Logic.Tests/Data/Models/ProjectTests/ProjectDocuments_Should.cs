using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class ProjectDocuments_Should
    {
        [Test]
        public void SetProjectDocuments_Correct()
        {
            var projectDocuments = new HashSet<ProjectDocument>();
            var project = new Project();

            project.ProjectDocuments = projectDocuments;

            Assert.AreSame(projectDocuments, project.ProjectDocuments);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("ProjectDocuments").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
