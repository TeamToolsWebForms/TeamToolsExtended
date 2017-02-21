using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsAddUserProjectPresenterTests
{
    [TestFixture]
    public class View_LoadOrganizationUsersUnsignedToProject_Should
    {
        [Test]
        public void CallProjectService_GetUnsignedOrgUsersToProjectOnce()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var viewModel = new ProjectDetailsAddUserProjectViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);
            int projectId = 12;
            int organizationId = 4334;

            mockedView.Raise(x => x.LoadOrganizationUsersUnsignedToProject += null, new ProjectDetailsAddUserProjectEventArgs(projectId, organizationId));

            mockedProjectService.Verify(x => x.GetUnsignedOrgUsersToProject(It.Is<int>(i => i == projectId), It.Is<int>(o => o == organizationId)), Times.Once);
        }

        [Test]
        public void SetViewModel_CorrectValue()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var viewModel = new ProjectDetailsAddUserProjectViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            mockedProjectService.Setup(x => x.GetUnsignedOrgUsersToProject(It.IsAny<int>(), It.IsAny<int>())).Returns("justjson");

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);
            int projectId = 12;
            int organizationId = 4334;
            string expected = "justjson";

            mockedView.Raise(x => x.LoadOrganizationUsersUnsignedToProject += null, new ProjectDetailsAddUserProjectEventArgs(projectId, organizationId));

            Assert.AreEqual(expected, mockedView.Object.Model.UsersUnsignedToProjectJson);
        }
    }
}
