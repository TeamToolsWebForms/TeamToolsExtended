using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeImortantNotesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenNoteService_IsNull()
        {
            var mockedView = new Mock<IImportantNoteView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomeImortantNotesPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Note Service"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomeImortantNotesPresenter_Correct()
        {
            var mockedView = new Mock<IImportantNoteView>();
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeImortantNotesPresenter(mockedView.Object, mockedNoteService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomeImortantNotesPresenter>(presenter);
        }
    }
}
