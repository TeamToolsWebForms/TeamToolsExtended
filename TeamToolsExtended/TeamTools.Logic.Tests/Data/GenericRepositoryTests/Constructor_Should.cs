using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Contracts;
using System;

namespace TeamTools.Logic.Tests.Data.GenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeInstanceOfIRepository_Correct()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();

            var repo = new GenericRepository<User>(mockedDbContext.Object);

            Assert.IsInstanceOf<IRepository<User>>(repo);
        }

        [Test]
        public void NotBeNull()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();

            var repo = new GenericRepository<User>(mockedDbContext.Object);

            Assert.IsNotNull(repo);
        }

        [Test]
        public void Throw_WhenDbContextIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new GenericRepository<Note>(null));
            Assert.That(ex.Message.Contains("DbContext"));
        }
    }
}
