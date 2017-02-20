using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using System.Linq.Expressions;

namespace TeamTools.Logic.Tests.Services.NoteServiceTests
{
    [TestFixture]
    public class GetAllImportantUserNotes
    {
        [Test]
        public void CallNoteRepository_AllOnce()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            string id = "test";

            noteService.GetAllImportantUserNotes(id);

            mockedNoteRepository.Verify(r => r.All(It.IsAny<Expression<Func<Note, bool>>>(), It.IsAny<Expression<Func<Note, int>>>(), It.IsAny<bool>()));
        }
    }
}
