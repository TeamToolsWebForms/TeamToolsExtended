using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class Users_Should
    {
        [Test]
        public void SetUsers_Correct()
        {
            var projectMembers = new HashSet<User>();
            var project = new Project();

            project.Users = projectMembers;

            Assert.AreSame(projectMembers, project.Users);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("Users").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
