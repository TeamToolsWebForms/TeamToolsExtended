using NUnit.Framework;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using Moq;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Organizations_Should
    {
        [Test]
        public void SetOrganizations_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            context.Organizations = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.Organizations);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("Organizations").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
