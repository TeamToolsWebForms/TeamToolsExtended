using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.ProjectTaskServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectTaskRepository_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                null,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object));
            Assert.That(ex.Message.Contains("ProjectTask Repository"));
        }

        [Test]
        public void ThrowsWhenProjectRepository_IsNull()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                null,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object));
            Assert.That(ex.Message.Contains("Project Repository"));
        }

        [Test]
        public void ThrowsWhenUserRepository_IsNull()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedJsonService.Object));
            Assert.That(ex.Message.Contains("User Repository"));
        }

        [Test]
        public void ThrowsWhenUnitOfWork_IsNull()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                null,
                mockedMapper.Object,
                mockedJsonService.Object));
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhenMapperService_IsNull()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedJsonService.Object));
            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhenJsonService_IsNull()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectTaskService(
                mockedProjectTaskRepository.Object,
                mockedProjectRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                null));
            Assert.That(ex.Message.Contains("Json Service"));
        }

        [Test]
        public void ReturnInstanceOfProjectTaskService_Correct()
        {
            var mockedProjectTaskRepository = new Mock<IRepository<ProjectTask>>();
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

            Assert.IsNotNull(projectTaskService);
            Assert.IsInstanceOf<ProjectTaskService>(projectTaskService);
        }
    }
}
