using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.CreateNotePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenNoteService_IsNull()
        {
            var mockedView = new Mock<ICreateNoteView>();
            var mockedNoteFactory = new Mock<INoteDTOFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new CreateNotePresenter(
                mockedView.Object,
                null,
                mockedNoteFactory.Object));
            Assert.That(ex.Message.Contains("Note Service"));
        }

        [Test]
        public void ThrowsWhenNoteFactory_IsNull()
        {
            var mockedView = new Mock<ICreateNoteView>();
            var mockedNoteService = new Mock<INoteService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new CreateNotePresenter(
                mockedView.Object,
                mockedNoteService.Object,
                null));
            Assert.That(ex.Message.Contains("Note Factory"));
        }

        [Test]
        public void ReturnInstanceOfCreateNotePresenter_Correct()
        {
            var mockedView = new Mock<ICreateNoteView>();
            var mockedNoteService = new Mock<INoteService>();
            var mockedNoteFactory = new Mock<INoteDTOFactory>();

            var presenter = new CreateNotePresenter(mockedView.Object, mockedNoteService.Object, mockedNoteFactory.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<CreateNotePresenter>(presenter);
        }
    }
}
