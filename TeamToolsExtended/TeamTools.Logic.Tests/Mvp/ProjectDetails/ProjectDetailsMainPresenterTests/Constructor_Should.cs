using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsMainPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var mockedMessageService = new Mock<IMessageService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsMainPresenter(
                mockedView.Object,
                null,
                mockedMessageService.Object));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ThrowsWhenMessageService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var mockedProjectService = new Mock<IProjectService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsMainPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                null));
            Assert.That(ex.Message.Contains("Message Service"));
        }

        [Test]
        public void ReturnInstanceOfProjectDetailsMainPresenter_Correct()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedMessageService = new Mock<IMessageService>();

            var presenter = new ProjectDetailsMainPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedMessageService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDetailsMainPresenter>(presenter);
        }
    }
}
