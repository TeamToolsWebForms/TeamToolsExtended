using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsAddUserProjectPresenterTests
{
    [TestFixture]
    public class View_AddUserToProject_Should
    {
        [Test]
        public void CallProjectService_AddUserToProjectOnce()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);
            int projectId = 12;
            int organizationId = 4334;
            string email = "test";

            mockedView.Raise(x => x.AddUserToProject += null, new ProjectDetailsAddUserProjectEventArgs(projectId, organizationId, email));

            mockedProjectService.Verify(x => x.AddUserToProject(It.Is<int>(i => i == projectId), It.Is<int>(o => o == organizationId), It.Is<string>(e => e == email)), Times.Once);
        }
    }
}
