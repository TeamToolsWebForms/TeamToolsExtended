using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectTasksPresenterTests
{
    [TestFixture]
    public class View_LoadEditedTask_Should
    {
        [Test]
        public void CallProjectTaskService_GetByIdOnce()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var presenter = new ProjectTasksPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object);
            int id = 312;

            mockedView.Raise(x => x.LoadEditedTask += null, new ProjectDetailsEventArgs(id));

            mockedProjectTaskService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
