using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using System.Linq.Expressions;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class AssignUserToTask_Should
    {
        [Test]
        public void CallProjectTaskRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var users = new List<User>() { new User() { UserName = "test" } };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
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
            int id = 213;
            string username = "test";

            projectTaskService.AssignUserToTask(id, username);

            mockedProjectTaskRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallUserRepository_AllOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var users = new List<User>() { new User() { UserName = "test" } };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
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
            int id = 213;
            string username = "test";

            projectTaskService.AssignUserToTask(id, username);

            mockedUserRepository.Verify(x => x.All(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [Test]
        public void ThrowsWhenNoUserIsFound()
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
            int id = 213;
            string username = "test";

            var ex = Assert.Throws<ArgumentNullException>(() => projectTaskService.AssignUserToTask(id, username));
            Assert.That(ex.Message.Contains("User"));
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var users = new List<User>() { new User() { UserName = "test" } };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
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
            int id = 213;
            string username = "test";

            projectTaskService.AssignUserToTask(id, username);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
