using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjects;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjects.MyProjectsPresenterTests
{
    [TestFixture]
    public class View_UpdateUserProject_Should
    {
        [Test]
        public void CallProjectService_UpdateOnce()
        {
            var mockedView = new Mock<IMyProjectsView>();
            var viewModel = new MyProjectsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new MyProjectsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedUserService.Object);

            int projectId = 12;
            string projectName = "test name";
            string id = "21312-1231";
            string username = "test";

            mockedView.Raise(x => x.UpdateUserProject += null, new MyProjectsEventArgs(id, username, projectId, projectName));

            mockedProjectService.Verify(x => x.Update(It.Is<int>(i => i == projectId), It.Is<string>(n => n == projectName)), Times.Once);
        }

        [Test]
        public void CallUserService_GetByIdWithFilteredProjectsOnce()
        {
            var mockedView = new Mock<IMyProjectsView>();
            var viewModel = new MyProjectsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new MyProjectsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedUserService.Object);

            int projectId = 12;
            string projectName = "test name";
            string id = "21312-1231";
            string username = "test";

            mockedView.Raise(x => x.UpdateUserProject += null, new MyProjectsEventArgs(id, username, projectId, projectName));

            mockedUserService.Verify(x => x.GetByIdWithFilteredProjects(It.Is<string>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }
    }
}
