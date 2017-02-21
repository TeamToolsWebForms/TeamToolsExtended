using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectTasksPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTasksPresenter(
                mockedView.Object,
                null,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ThrowsWhenProjectTaskService_IsNull()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTasksPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                null,
                mockedProjectTaskFactory.Object));
            Assert.That(ex.Message.Contains("ProjectTask Service"));
        }

        [Test]
        public void ThrowsWhenProjectTaskFactory_IsNull()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTasksPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                null));
            Assert.That(ex.Message.Contains("ProjectTask Factory"));
        }

        [Test]
        public void ReturnInstanceOfProjectTasksPresenter_Correct()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var presenter = new ProjectTasksPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectTasksPresenter>(presenter);
        }
    }
}
