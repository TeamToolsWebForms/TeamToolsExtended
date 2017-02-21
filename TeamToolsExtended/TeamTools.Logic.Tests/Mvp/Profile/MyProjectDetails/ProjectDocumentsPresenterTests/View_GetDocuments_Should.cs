using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDocumentsPresenterTests
{
    [TestFixture]
    public class View_GetDocuments_Should
    {
        [Test]
        public void CallProjectService_GetByIdOnce()
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

            mockedView.Raise(x => x.GetDocuments += null, new ProjectDetailsEventArgs(id));

            mockedProjectService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
