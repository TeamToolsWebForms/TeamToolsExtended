using NUnit.Framework;
using Moq;
using System.Data.Entity;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class ProjectTasks_Should
    {
        [Test]
        public void SetProjectTasks_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<ProjectTask>>();
            var context = new TeamToolsDbContext();

            context.ProjectTasks = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.ProjectTasks);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("ProjectTasks").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
