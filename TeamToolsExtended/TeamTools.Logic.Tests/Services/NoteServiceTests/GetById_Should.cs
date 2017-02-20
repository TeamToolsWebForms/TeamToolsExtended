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
    public class GetById_Should
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
            int id = 12;

            noteService.GetById(id);

            mockedNoteRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void ReturnNoteDTO_Correct()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var note = new NoteDTO("test", "test", "test");
            mockedMapper.Setup(x => x.MapObject<NoteDTO>(It.IsAny<Note>())).Returns(note);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            int id = 12;

            var result = noteService.GetById(id);

            Assert.AreSame(note, result);
        }
    }
}
