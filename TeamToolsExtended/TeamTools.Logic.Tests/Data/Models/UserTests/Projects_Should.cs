using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class Projects_Should
    {
        [Test]
        public void SetProjects_Correct()
        {
            var personalProjects = new HashSet<Project>();
            var user = new User();

            user.Projects = personalProjects;

            Assert.AreSame(personalProjects, user.Projects);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("Projects").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
