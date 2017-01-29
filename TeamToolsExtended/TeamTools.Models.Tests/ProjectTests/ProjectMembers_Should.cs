using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class ProjectMembers_Should
    {
        [Test]
        public void SetProjectMembers_Correct()
        {
            var projectMembers = new HashSet<User>();
            var project = new Project();

            project.ProjectMembers = projectMembers;

            Assert.AreSame(projectMembers, project.ProjectMembers);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("ProjectMembers").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
