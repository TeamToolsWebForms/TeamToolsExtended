using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDocumentsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IMyProjectDocumentsView>();
            var mockedFileService = new Mock<IFileService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDocumentsPresenter(
                mockedView.Object,
                null,
                mockedFileService.Object));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ThrowsWhenFileService_IsNull()
        {
            var mockedView = new Mock<IMyProjectDocumentsView>();
            var mockedProjectService = new Mock<IProjectService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDocumentsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                null));
            Assert.That(ex.Message.Contains("File Service"));
        }

        [Test]
        public void ReturnInstanceOfProjectDocumentsPresenter_Correct()
        {
            var mockedView = new Mock<IMyProjectDocumentsView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedFileService = new Mock<IFileService>();

            var presenter = new ProjectDocumentsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedFileService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDocumentsPresenter>(presenter);
        }
    }
}
