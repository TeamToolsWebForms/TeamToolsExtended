using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Contracts;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.GenericRepositoryTests
{
    public class Update_Should
    {
        [Test]
        public void CallStateFactory_Once()
        {
            var mockedNote = new Mock<Note>();
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var mockedEntryState = new Mock<IEntryState<Note>>();
            mockedEntryState.Object.State = EntityState.Modified;
            mockedDbContext.Setup(x => x.GetState(mockedNote.Object)).Returns(mockedEntryState.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            repo.Update(mockedNote.Object);

            mockedDbContext.Verify(x => x.GetState(mockedNote.Object), Times.Once);
        }

        [Test]
        public void Throw_WhenEntityIsNull()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => repo.Update(null));
            Assert.That(ex.Message.Contains("Entity"));
        }
    }
}
