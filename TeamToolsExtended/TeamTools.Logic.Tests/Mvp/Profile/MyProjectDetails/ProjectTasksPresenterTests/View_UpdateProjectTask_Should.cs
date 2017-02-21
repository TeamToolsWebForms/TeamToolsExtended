using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectTasksPresenterTests
{
    [TestFixture]
    public class View_UpdateProjectTask_Should
    {
        [Test]
        public void CallProjectTaskService_UpdateOnce()
        {
            var mockedView = new Mock<IProjectTasksView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedProjectTaskService = new Mock<IProjectTaskService>();
            var mockedProjectTaskFactory = new Mock<IProjectTaskFactory>();

            var presenter = new ProjectTasksPresenter(
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

            mockedView.Raise(x => x.UpdateProjectTask += null, new ProjectDetailsEventArgs(title, description, dueDate, cost, status, id));

            mockedProjectTaskService.Verify(x => x.Update(
                It.Is<int>(i => i == id),
                It.Is<string>(t => t == title),
                It.Is<string>(d => d == description),
                It.Is<DateTime?>(s => s == dueDate),
                It.Is<decimal>(c => c == cost),
                It.Is<TaskType>(y => y == status)), Times.Once);
        }
    }
}
