using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsOrganizationPresenterTests
{
    [TestFixture]
    public class View_IsUserToAssignValid_Should
    {
        [Test]
        public void CallProjectTaskService_IsUserToAssignValidOnce()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var presenter = new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object);
            int id = 312;
            string username = "test";

            mockedView.Raise(x => x.IsUserToAssignValid += null, new ProjectDetailsEventArgs(id, username));

            mockedProjectTaskService.Verify(x => x.IsUserToAssignValid(It.Is<int>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void SetViewModelCorrect()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            mockedProjectTaskService.Setup(x => x.IsUserToAssignValid(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var presenter = new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object);
            int id = 312;
            string username = "test";

            mockedView.Raise(x => x.IsUserToAssignValid += null, new ProjectDetailsEventArgs(id, username));

            Assert.IsTrue(mockedView.Object.Model.IsUserInValid);
        }
    }
}
