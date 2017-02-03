using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class Project_Should
    {
        [Test]
        public void SetProject_Correct()
        {
            var project = new Mock<Project>();
            var projectTask = new ProjectTask();

            projectTask.Project = project.Object;

            Assert.AreSame(project.Object, projectTask.Project);
        }

        [Test]
        public void BeVirtual()
        {
            var projectTask = new ProjectTask();

            bool isVirtual = projectTask.GetType().GetProperty("Project").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
