using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class GetUsersNotSignedToTask_Should
    {
        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
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
            int taskId = 213;
            int projectId = 345;

            projectTaskService.GetUsersNotSignedToTask(taskId, projectId);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == projectId)), Times.Once);
        }

        [Test]
        public void CallProjectTaskRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
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
            int taskId = 213;
            int projectId = 345;

            projectTaskService.GetUsersNotSignedToTask(taskId, projectId);

            mockedProjectTaskRepository.Verify(x => x.GetById(It.Is<int>(i => i == taskId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            project.Users.Add(new User() { UserName = "Smith" });
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();
            mockedJsonService.Setup(x => x.GetAsJson(It.IsAny<object>())).Returns("Smith");

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int taskId = 213;
            int projectId = 345;

            var result = projectTaskService.GetUsersNotSignedToTask(taskId, projectId);

            Assert.AreEqual("Smith", result);   
        }
    }
}
