using NUnit.Framework;
using Moq;
using System;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Contracts;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeTeamToolsDbContext_Correct()
        {
            var context = new TeamToolsDbContext();

            Assert.IsNotNull(context);
        }

        [Test]
        public void ThrowWhenStateFactory_IsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new TeamToolsDbContext(null));
            Assert.That(ex.Message.Contains("StateFactory"));
        }

        [Test]
        public void InitializeTeamToolsDbContext_CorrectWhenStateFactoryIsSet()
        {
            var mockedFactory = new Mock<IStateFactory>();
            var context = new TeamToolsDbContext(mockedFactory.Object);

            Assert.IsNotNull(context);
        }
    }
}
