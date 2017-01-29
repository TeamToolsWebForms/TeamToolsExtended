using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.ProjectTaskTests
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
