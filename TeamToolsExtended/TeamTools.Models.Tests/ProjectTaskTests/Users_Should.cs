using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class Users_Should
    {
        [Test]
        public void SetUsers_Correct()
        {
            var relatedUsers = new HashSet<User>();
            var projectTask = new ProjectTask();

            projectTask.Users = relatedUsers;

            Assert.AreSame(relatedUsers, projectTask.Users);
        }

        [Test]
        public void BeVirtual()
        {
            var projectTask = new ProjectTask();

            bool isVirtual = projectTask.GetType().GetProperty("Users").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
