using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;

namespace TeamTools.Logic.Tests.Data.GenericRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void CallStateFactory_Once()
        {
            var mockedNote = new Mock<Note>();
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var mockedEntryState = new Mock<IEntryState<Note>>();
            mockedEntryState.Object.State = EntityState.Added;
            mockedDbContext.Setup(x => x.GetState(mockedNote.Object)).Returns(mockedEntryState.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            repo.Add(mockedNote.Object);

            mockedDbContext.Verify(x => x.GetState(mockedNote.Object), Times.Once);
        }

        [Test]
        public void Throw_WhenEntityIsNull()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => repo.Add(null));
            Assert.That(ex.Message.Contains("Entity"));
        }
    }
}
