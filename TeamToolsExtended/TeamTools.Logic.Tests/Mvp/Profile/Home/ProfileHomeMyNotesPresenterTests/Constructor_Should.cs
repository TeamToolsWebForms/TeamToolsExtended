using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeMyNotesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenNoteService_IsNull()
        {
            var mockedView = new Mock<IMyNotesView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomeMyNotesPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Note Service"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomeMyNotesPresenter_Correct()
        {
            var mockedView = new Mock<IMyNotesView>();
            var mockedNoteService = new Mock<INoteService>();

            var presenter = new ProfileHomeMyNotesPresenter(mockedView.Object, mockedNoteService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomeMyNotesPresenter>(presenter);
        }
    }
}
