using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class CreatePersonalProject_Should
    {
        [Test]
        public void CallProjectFactor_Once()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreatePersonalProject(title, description, username);

            mockedProjectFactory.Verify(x => x.CreateProject(It.Is<string>(t => t == title), It.Is<string>(d => d == description), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_AddOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreatePersonalProject(title, description, username);

            mockedProjectRepository.Verify(x => x.Add(It.Is<Project>(p => p == project && project.IsPersonal == true)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string title = "test title";
            string description = "test description";
            string username = "testusername";

            projectService.CreatePersonalProject(title, description, username);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
