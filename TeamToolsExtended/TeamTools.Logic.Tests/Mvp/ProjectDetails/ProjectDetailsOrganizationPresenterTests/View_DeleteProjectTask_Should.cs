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
    public class View_DeleteProjectTask_Should
    {
        [Test]
        public void CallProjectTaskService_DeleteOnce()
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

            mockedView.Raise(x => x.DeleteProjectTask += null, new ProjectDetailsEventArgs(id));

            mockedProjectTaskService.Verify(x => x.Delete(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
