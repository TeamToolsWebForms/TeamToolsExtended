using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallProjectTaskRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 23;
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = DateTime.Now;
            decimal cost = 12M;
            TaskType status = TaskType.Done;

            projectTaskService.Update(id, title, description, dueDate, cost, status);

            mockedProjectTaskRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallProjectTaskRepository_UpdateOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 23;
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = DateTime.Now;
            decimal cost = 12M;
            TaskType status = TaskType.Done;

            projectTaskService.Update(id, title, description, dueDate, cost, status);

            mockedProjectTaskRepository
                .Verify(x => x
                    .Update(
                        It.Is<ProjectTask>(
                            t => t == projectTask &&
                            t.Title == title &&
                            t.Description == description &&
                            t.DueDate == dueDate &&
                            t.ExecutionCost == cost &&
                            t.Status == status)),
                            Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 23;
            string title = "test title";
            string description = "test description";
            DateTime? dueDate = DateTime.Now;
            decimal cost = 12M;
            TaskType status = TaskType.Done;

            projectTaskService.Update(id, title, description, dueDate, cost, status);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
