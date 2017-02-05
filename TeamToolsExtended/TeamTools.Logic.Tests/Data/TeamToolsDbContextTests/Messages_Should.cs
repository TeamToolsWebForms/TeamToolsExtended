using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Messages_Should
    {
        [Test]
        public void SetMessages_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<Message>>();
            var context = new TeamToolsDbContext();

            context.Messages = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.Messages);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("Messages").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
