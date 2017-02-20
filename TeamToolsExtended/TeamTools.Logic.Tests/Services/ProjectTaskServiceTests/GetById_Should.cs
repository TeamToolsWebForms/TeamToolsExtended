using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallProjectTaskRepository_GetByIdOnce()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
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
            int id = 23;

            projectTaskService.GetById(id);

            mockedProjectTaskRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallMapperService_Once()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTaskDTO = new ProjectTaskDTO();
            mockedMapper.Setup(x => x.MapObject<ProjectTaskDTO>(It.IsAny<ProjectTask>())).Returns(projectTaskDTO);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 23;

            projectTaskService.GetById(id);

            mockedMapper.Verify(x => x.MapObject<ProjectTaskDTO>(It.Is<ProjectTask>(t => t == projectTask)), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var projectTask = new ProjectTask();
            mockedProjectTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectTask);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var projectTaskDTO = new ProjectTaskDTO();
            mockedMapper.Setup(x => x.MapObject<ProjectTaskDTO>(It.IsAny<ProjectTask>())).Returns(projectTaskDTO);
            var mockedJsonService = new Mock<IJsonService>();

            var projectTaskService = new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 23;

            var result = projectTaskService.GetById(id);

            Assert.AreSame(projectTaskDTO, result);
        }
    }
}
