using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization.Contracts;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsOrganizationPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                null,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ThrowsWhenProjectTaskService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                null,
                mockedProjectTaskFactory.Object));
            Assert.That(ex.Message.Contains("ProjectTask Service"));
        }

        [Test]
        public void ThrowsWhenProjectTaskFactory_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                null));
            Assert.That(ex.Message.Contains("ProjectTask Factory"));
        }

        [Test]
        public void ReturnInstanceOfProjectTasksPresenter_Correct()
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

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDetailsOrganizationPresenter>(presenter);
        }
    }
}
