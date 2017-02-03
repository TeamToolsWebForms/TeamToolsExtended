using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
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
