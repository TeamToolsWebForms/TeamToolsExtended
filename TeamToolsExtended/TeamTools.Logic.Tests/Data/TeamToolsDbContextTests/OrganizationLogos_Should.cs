using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class OrganizationLogos_Should
    {
        [Test]
        public void SetOrganizationLogos_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<OrganizationLogo>>();
            var context = new TeamToolsDbContext();

            context.OrganizationLogos = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.OrganizationLogos);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("OrganizationLogos").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
