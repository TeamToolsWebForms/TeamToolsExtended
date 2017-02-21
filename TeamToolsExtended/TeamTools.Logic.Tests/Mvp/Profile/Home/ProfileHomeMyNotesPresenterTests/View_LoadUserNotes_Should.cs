using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeMyNotesPresenterTests
{
    [TestFixture]
    public class View_LoadUserNotes_Should
    {
        [Test]
        public void CallNoteService_GetAllUserNotesOnce()
        {
            var mockedView = new Mock<IMyNotesView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeMyNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string userId = "someid";

            mockedView.Raise(x => x.LoadUserNotes += null, new MyNotesEventArgs(userId));

            mockedNoteService.Verify(x => x.GetAllUserNotes(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IMyNotesView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();
            var notes = new List<NoteDTO>()
            {
                new NoteDTO("test1", "content test1", "some-id-1"),
                new NoteDTO("test2", "content test2", "some-id-2"),
                new NoteDTO("test3", "content test3", "some-id-3")
            };
            mockedNoteService.Setup(x => x.GetAllUserNotes(It.IsAny<string>())).Returns(notes);

            var presenter = new ProfileHomeMyNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string userId = "someid";

            mockedView.Raise(x => x.LoadUserNotes += null, new MyNotesEventArgs(userId));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.UserNotes, notes);
        }
    }
}
