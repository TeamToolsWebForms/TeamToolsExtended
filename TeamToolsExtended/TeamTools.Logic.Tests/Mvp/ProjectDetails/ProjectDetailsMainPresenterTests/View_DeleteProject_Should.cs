using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsMainPresenterTests
{
    [TestFixture]
    public class View_DeleteProject_Should
    {
        [Test]
        public void CallProjectService_DeleteOnce()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var viewModel = new ProjectDetailsMainViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedMessageService = new Mock<IMessageService>();

            var presenter = new ProjectDetailsMainPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedMessageService.Object);
            int id = 32;

            mockedView.Raise(x => x.DeleteProject += null, new ProjectDetailsMainEventArgs(id));

            mockedProjectService.Verify(x => x.Delete(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
