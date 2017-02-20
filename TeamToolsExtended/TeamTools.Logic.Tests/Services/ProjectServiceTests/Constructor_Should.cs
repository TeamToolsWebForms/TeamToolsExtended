using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.ProjectServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectRepository_IsNull()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                null,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object));

            Assert.That(ex.Message.Contains("Project Repository"));
        }

        [Test]
        public void ThrowsWhenOrganizationRepository_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                mockedProjectRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object));

            Assert.That(ex.Message.Contains("Organization Repository"));
        }

        [Test]
        public void ThrowsWhenUnitOfWork_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                null,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object));

            Assert.That(ex.Message.Contains("Unit of work"));
        }

        [Test]
        public void ThrowsWhenProjectFactory_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedMapper.Object,
                mockedJsonService.Object));

            Assert.That(ex.Message.Contains("Project Factory"));
        }

        [Test]
        public void ThrowsWhenMapperService_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedJsonService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                null,
                mockedJsonService.Object));

            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhenJsonService_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                null));

            Assert.That(ex.Message.Contains("Json Service"));
        }

        [Test]
        public void ReturnInstanceOfProjectService_Correct()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);

            Assert.IsNotNull(projectService);
            Assert.IsInstanceOf<ProjectService>(projectService);
        }
    }
}
