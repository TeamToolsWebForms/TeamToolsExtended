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
    public class CreateOrganizationProject_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var project = new Project();
            mockedProjectFactory.Setup(x => x.CreateProject(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(project);
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 123;
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreateOrganizationProject(id, title, description, username);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallProjectFactory_Once()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var project = new Project();
            mockedProjectFactory.Setup(x => x.CreateProject(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(project);
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 123;
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreateOrganizationProject(id, title, description, username);

            mockedProjectFactory.Verify(x => x.CreateProject(It.Is<string>(t => t == title), It.Is<string>(d => d == description), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_AddOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var project = new Project();
            mockedProjectFactory.Setup(x => x.CreateProject(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(project);
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 123;
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreateOrganizationProject(id, title, description, username);

            mockedProjectRepository.Verify(x => x.Add(It.Is<Project>(p => p == project)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var project = new Project();
            mockedProjectFactory.Setup(x => x.CreateProject(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(project);
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 123;
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreateOrganizationProject(id, title, description, username);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
