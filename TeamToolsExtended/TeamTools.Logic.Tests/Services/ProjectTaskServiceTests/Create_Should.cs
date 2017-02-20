using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallMapperService_Once()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTask = new ProjectTask();
            mockedMapper.Setup(x => x.MapObject<ProjectTask>(It.IsAny<ProjectTaskDTO>())).Returns(projectTask);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            var projectTaskDTO = new ProjectTaskDTO();

            projectTaskService.Create(projectTaskDTO);

            mockedMapper.Verify(x => x.MapObject<ProjectTask>(It.Is<ProjectTaskDTO>(t => t == projectTaskDTO)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTask = new ProjectTask();
            mockedMapper.Setup(x => x.MapObject<ProjectTask>(It.IsAny<ProjectTaskDTO>())).Returns(projectTask);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            var projectTaskDTO = new ProjectTaskDTO();

            projectTaskService.Create(projectTaskDTO);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == projectTaskDTO.ProjectId)), Times.Once);
        }

        [Test]
        public void CallProjectTaskRepository_AddOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTask = new ProjectTask();
            mockedMapper.Setup(x => x.MapObject<ProjectTask>(It.IsAny<ProjectTaskDTO>())).Returns(projectTask);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            var projectTaskDTO = new ProjectTaskDTO();

            projectTaskService.Create(projectTaskDTO);

            mockedProjectTaskRepository.Verify(x => x.Add(It.Is<ProjectTask>(t => t == projectTask)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTask = new ProjectTask();
            mockedMapper.Setup(x => x.MapObject<ProjectTask>(It.IsAny<ProjectTaskDTO>())).Returns(projectTask);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            var projectTaskDTO = new ProjectTaskDTO();

            projectTaskService.Create(projectTaskDTO);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
