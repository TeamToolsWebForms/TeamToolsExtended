using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.NoteServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallMapperOnce()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var noteMock = new NoteDTO("test", "test", "test");

            noteService.Create(noteMock);

            mockedMapper.Verify(x => x.MapObject<Note>(It.Is<NoteDTO>(n => n == noteMock)), Times.Once);
        }

        [Test]
        public void CallNoteRepository_AddOnce()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedNote = new Mock<Note>();
            mockedMapper.Setup(x => x.MapObject<Note>(It.IsAny<NoteDTO>())).Returns(mockedNote.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var note = new NoteDTO("test", "test", "test");

            noteService.Create(note);

            mockedNoteRepository.Verify(x => x.Add(It.Is<Note>(n => n == mockedNote.Object)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var note = new NoteDTO("test", "test", "test");

            noteService.Create(note);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
