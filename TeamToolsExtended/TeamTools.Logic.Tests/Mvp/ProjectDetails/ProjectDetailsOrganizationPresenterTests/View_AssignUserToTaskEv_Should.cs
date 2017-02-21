using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsOrganizationPresenterTests
{
    [TestFixture]
    public class View_AssignUserToTaskEv_Should
    {
        [Test]
        public void CallProjectTaskService_AssignUserToTaskOnce()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
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

            mockedView.Raise(x => x.AssignUserToTaskEv += null, new ProjectDetailsEventArgs(id, username));

            mockedProjectTaskService.Verify(x => x.AssignUserToTask(It.Is<int>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }
    }
}
