using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.CreateNotePresenterTests
{
    [TestFixture]
    public class View_CreateNote_Should
    {
        [Test]
        public void CallNoteFactory_CreateOnce()
        {
            var mockedView = new Mock<ICreateNoteView>();
            var mockedNoteService = new Mock<INoteService>();
            var mockedNoteFactory = new Mock<INoteDTOFactory>();

            var presenter = new CreateNotePresenter(mockedView.Object, mockedNoteService.Object, mockedNoteFactory.Object);
            string title = "test";
            string content = "test content";
            string userId = "123321-21312";

            mockedView.Raise(x => x.CreateNewNote += null, new CreateNoteEventArgs(title, content, userId));

            mockedNoteFactory.Verify(x => x.CreateNote(It.Is<string>(t => t == title), It.Is<string>(c => c == content), It.Is<string>(u => u == userId)), Times.Once);
        }

        [Test]
        public void CallNoteService_CreateOnce()
        {
            var mockedView = new Mock<ICreateNoteView>();
            var mockedNoteService = new Mock<INoteService>();
            var mockedNoteFactory = new Mock<INoteDTOFactory>();
            string title = "test";
            string content = "test content";
            string userId = "123321-21312";
            var noteDTO = new NoteDTO(title, content, userId);
            mockedNoteFactory.Setup(x => x.CreateNote(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(noteDTO);
            var presenter = new CreateNotePresenter(mockedView.Object, mockedNoteService.Object, mockedNoteFactory.Object);
            

            mockedView.Raise(x => x.CreateNewNote += null, new CreateNoteEventArgs(title, content, userId));

            mockedNoteService.Verify(x => x.Create(It.Is<NoteDTO>(n => n == noteDTO)), Times.Once);
        }
    }
}
