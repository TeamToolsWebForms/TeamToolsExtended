using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class ProjectTasks_Should
    {
        [Test]
        public void SetProjectTasks_Correct()
        {
            var tasks = new HashSet<ProjectTask>();
            var project = new Project();

            project.ProjectTasks = tasks;

            Assert.AreSame(tasks, project.ProjectTasks);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("ProjectTasks").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
