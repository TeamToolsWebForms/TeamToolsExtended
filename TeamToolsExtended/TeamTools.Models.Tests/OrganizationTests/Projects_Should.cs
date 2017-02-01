using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.OrganizationTests
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
