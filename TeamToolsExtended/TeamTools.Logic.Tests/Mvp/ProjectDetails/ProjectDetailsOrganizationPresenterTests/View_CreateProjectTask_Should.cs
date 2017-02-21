using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization;
using TeamTools.Logic.Data.Models.Enums;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsOrganizationPresenterTests
{
    [TestFixture]
    public class View_CreateProjectTask_Should
    {
        [Test]
        public void CallProjectTaskFactory_Once()
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
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = new DateTime(2000, 12, 12);
            decimal cost = 32M;
            TaskType status = TaskType.Done;

            mockedView.Raise(x => x.CreateProjectTask += null, new ProjectDetailsEventArgs(title, description, dueDate, cost, status, id));

            mockedProjectTaskFactory.Verify(x => x.CreateProjectTask(
                It.Is<string>(t => t == title),
                It.Is<string>(d => d == description),
                It.Is<DateTime?>(s => s == dueDate),
                It.Is<decimal>(c => c == cost),
                It.Is<TaskType>(y => y == status),
                It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallProjectTaskService_CreateOnce()
        {
            var mockedView = new Mock<IProjectDetailsOrganizationView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();
            var projectTask = new ProjectTaskDTO();
            mockedProjectTaskFactory.Setup(x => x.CreateProjectTask(
                 It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime?>(),
                It.IsAny<decimal>(),
                It.IsAny<TaskType>(),
                It.IsAny<int>())).Returns(projectTask);

            var presenter = new ProjectDetailsOrganizationPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedProjectTaskService.Object,
                mockedProjectTaskFactory.Object);
            int id = 312;
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = new DateTime(2000, 12, 12);
            decimal cost = 32M;
            TaskType status = TaskType.Done;

            mockedView.Raise(x => x.CreateProjectTask += null, new ProjectDetailsEventArgs(title, description, dueDate, cost, status, id));

            mockedProjectTaskService.Verify(x => x.Create(It.Is<ProjectTaskDTO>(p => p == projectTask)), Times.Once);
        }

        [Test]
        public void CallProjectService_GetByIdOnce()
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
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = new DateTime(2000, 12, 12);
            decimal cost = 32M;
            TaskType status = TaskType.Done;

            mockedView.Raise(x => x.CreateProjectTask += null, new ProjectDetailsEventArgs(title, description, dueDate, cost, status, id));

            mockedProjectService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
