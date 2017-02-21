using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeImortantNotesPresenterTests
{
    [TestFixture]
    public class View_LoadImportantUserNotes_Should
    {
        [Test]
        public void CallNoteService_GetAllImportantUserNotesOnce()
        {
            var mockedView = new Mock<IImportantNoteView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeImortantNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string id = "12";

            mockedView.Raise(x => x.LoadImportantUserNotes += null, new MyNotesEventArgs(id));

            mockedNoteService.Verify(x => x.GetAllImportantUserNotes(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IImportantNoteView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();
            var notes = new List<NoteDTO>()
            {
                new NoteDTO("test1", "test content1", "some-1"),
                new NoteDTO("test2", "test content2", "some-2"),
                new NoteDTO("test3", "test content3", "some-3")
            };
            mockedNoteService.Setup(x => x.GetAllImportantUserNotes(It.IsAny<string>())).Returns(notes);

            var presenter = new ProfileHomeImortantNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string id = "12";

            mockedView.Raise(x => x.LoadImportantUserNotes += null, new MyNotesEventArgs(id));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.UserNotes, notes);
        }
    }
}
