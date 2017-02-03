using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class Projects_Should
    {
        [Test]
        public void SetProjects_Correct()
        {
            var projects = new HashSet<Project>();
            var organization = new Organization();

            organization.Projects = projects;

            Assert.AreSame(projects, organization.Projects);
        }

        [Test]
        public void BeVirtual()
        {
            var organization = new Organization();

            bool isVirtual = organization.GetType().GetProperty("Projects").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
