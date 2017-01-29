using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class Tasks_Should
    {
        [Test]
        public void SetTasks_Correct()
        {
            var tasks = new HashSet<ProjectTask>();
            var project = new Project();

            project.Tasks = tasks;

            Assert.AreSame(tasks, project.Tasks);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("Tasks").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
