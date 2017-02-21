using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeTrashNotesPresenterTests
{
    [TestFixture]
    public class View_LoadDeletedNotes_Should
    {
        [Test]
        public void CallNoteService_GetAllDeleteUserNotesOnce()
        {
            var mockedView = new Mock<ITrashNotesView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeTrashNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string id = "13123-43534";

            mockedView.Raise(x => x.LoadDeletedNotes += null, new MyNotesEventArgs(id));

            mockedNoteService.Verify(x => x.GetAllDeleteUserNotes(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewModelNotes_Correct()
        {
            var mockedView = new Mock<ITrashNotesView>();
            var viewModel = new MyNotesViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedNoteService = new Mock<INoteService>();
            var notes = new List<NoteDTO>()
            {
                new NoteDTO("test1", "content-test1", "user-id-1"),
                new NoteDTO("test2", "content-test2", "user-id-2"),
                new NoteDTO("test3", "content-test3", "user-id-3")
            };
            mockedNoteService.Setup(x => x.GetAllDeleteUserNotes(It.IsAny<string>())).Returns(notes);

            var presenter = new ProfileHomeTrashNotesPresenter(mockedView.Object, mockedNoteService.Object);
            string id = "13123-43534";

            mockedView.Raise(x => x.LoadDeletedNotes += null, new MyNotesEventArgs(id));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.UserNotes, notes);
        }
    }
}
