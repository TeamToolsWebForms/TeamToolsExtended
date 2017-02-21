using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeTrashNotesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenNoteService_IsNull()
        {
            var mockedView = new Mock<ITrashNotesView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomeTrashNotesPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Note Service"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomeTrashNotesPresenter_Correct()
        {
            var mockedView = new Mock<ITrashNotesView>();
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeTrashNotesPresenter(mockedView.Object, mockedNoteService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomeTrashNotesPresenter>(presenter);
        }
    }
}
