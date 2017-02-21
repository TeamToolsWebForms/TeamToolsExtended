using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectTasksPresenterTests
{
    [TestFixture]
    public class View_LoadProjectTasks_Should
    {
        [Test]
        public void CallProjectService_GetByIdOnce()
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

            mockedView.Raise(x => x.LoadProjectTasks += null, new ProjectDetailsEventArgs(id));

            mockedProjectService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
