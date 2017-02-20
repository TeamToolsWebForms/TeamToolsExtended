using NUnit.Framework;
using Moq;
using System.Data.Entity;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class ProjectDocuments_Should
    {
        [Test]
        public void SetProjectDocuments_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<ProjectDocument>>();
            var context = new TeamToolsDbContext();

            context.ProjectDocuments = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.ProjectDocuments);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("ProjectDocuments").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
