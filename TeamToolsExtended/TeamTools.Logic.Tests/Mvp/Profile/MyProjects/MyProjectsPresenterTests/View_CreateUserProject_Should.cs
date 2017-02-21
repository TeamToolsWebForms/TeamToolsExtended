using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.MyProjects;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjects.MyProjectsPresenterTests
{
    [TestFixture]
    public class View_CreateUserProject_Should
    {
        [Test]
        public void CallProjectService_CreatePersonalProjectOnce()
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

            string name = "test name";
            string description = "test description";
            string id = "21312-1231";
            string username = "test";

            mockedView.Raise(x => x.CreateUserProject += null, new MyProjectsEventArgs(id, username, name, description));

            mockedProjectService.Verify(x => x.CreatePersonalProject(It.Is<string>(n => n == name), It.Is<string>(d => d == description), It.Is<string>(u => u == username)), Times.Once);
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

            string name = "test name";
            string description = "test description";
            string id = "21312-1231";
            string username = "test";

            mockedView.Raise(x => x.CreateUserProject += null, new MyProjectsEventArgs(id, username, name, description));

            mockedUserService.Verify(x => x.GetByIdWithFilteredProjects(It.Is<string>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }
    }
}
