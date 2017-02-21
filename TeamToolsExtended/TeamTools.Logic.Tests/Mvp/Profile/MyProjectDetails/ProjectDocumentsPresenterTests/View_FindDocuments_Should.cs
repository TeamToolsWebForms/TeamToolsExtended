using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDocumentsPresenterTests
{
    [TestFixture]
    public class View_FindDocuments_Should
    {
        [Test]
        public void CallProjectService_GetByIdSearchedDocumentsOnce()
        {
            var mockedView = new Mock<IMyProjectDocumentsView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedFileService = new Mock<IFileService>();

            var presenter = new ProjectDocumentsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedFileService.Object);
            int id = 32;
            string pattern = "test";

            mockedView.Raise(x => x.FindDocuments += null, new ProjectDocumentsEventArgs(id, pattern));

            mockedProjectService.Verify(x => x.GetByIdSearchedDocuments(It.Is<int>(i => i == id), It.Is<string>(p => p == pattern)), Times.Once);
        }
    }
}
