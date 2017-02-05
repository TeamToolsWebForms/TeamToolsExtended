using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class UserLogos_Should
    {
        [Test]
        public void SetUserLogos_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<UserLogo>>();
            var context = new TeamToolsDbContext();

            context.UserLogos = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.UserLogos);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("UserLogos").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
