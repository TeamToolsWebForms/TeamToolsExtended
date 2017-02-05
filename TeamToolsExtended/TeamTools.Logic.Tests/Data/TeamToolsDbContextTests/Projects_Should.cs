using NUnit.Framework;
using Moq;
using System.Data.Entity;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Projects_Should
    {
        [Test]
        public void SetProjects_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<Project>>();
            var context = new TeamToolsDbContext();

            context.Projects = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.Projects);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("Projects").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
