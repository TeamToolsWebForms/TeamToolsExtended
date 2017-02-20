using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.NoteServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallNoteRepository_GetByIdOnce()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var note = new NoteDTO("test", "test", "test");
            note.Id = 1;

            noteService.Update(note);

            mockedNoteRepository.Verify(x => x.GetById(It.Is<int>(i => i == note.Id)), Times.Once);
        }

        [Test]
        public void CallMapper_Once()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var note = new Mock<Note>();
            mockedNoteRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(note.Object);
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var noteDTO = new NoteDTO("test", "test", "test");
            noteDTO.Id = 1;

            noteService.Update(noteDTO);

            mockedMapper.Verify(x => x.MapObject(It.Is<NoteDTO>(n => n == noteDTO), It.Is<Note>(n => n == note.Object)), Times.Once);
        }

        [Test]
        public void CallNoteRepository_UpdateOnce()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedNote = new Mock<Note>();
            mockedMapper.Setup(x => x.MapObject(It.IsAny<NoteDTO>(), It.IsAny<Note>())).Returns(mockedNote.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            var noteDTO = new NoteDTO("test", "test", "test");
            noteDTO.Id = 1;

            noteService.Update(noteDTO);

            mockedNoteRepository.Verify(x => x.Update(It.Is<Note>(n => n == mockedNote.Object)), Times.Once);
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
            var noteDTO = new NoteDTO("test", "test", "test");
            noteDTO.Id = 1;

            noteService.Update(noteDTO);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
