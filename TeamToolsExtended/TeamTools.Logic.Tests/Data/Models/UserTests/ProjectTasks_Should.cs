using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class ProjectTasks_Should
    {
        [Test]
        public void SetProjectTasks_Correct()
        {
            var projectTasks = new HashSet<ProjectTask>();
            var user = new User();

            user.ProjectTasks = projectTasks;

            Assert.AreSame(projectTasks, user.ProjectTasks);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("ProjectTasks").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
