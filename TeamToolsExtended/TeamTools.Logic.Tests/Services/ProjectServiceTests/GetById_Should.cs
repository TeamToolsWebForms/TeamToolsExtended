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
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.ProjectServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
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
            int id = 1;

            projectService.GetById(id);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallMapperService_Once()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            project.ProjectTasks = new List<ProjectTask>()
            {
                new ProjectTask() { IsDeleted = true },
                new ProjectTask() { IsDeleted = false }
            };

            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
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
            int id = 1;

            projectService.GetById(id);

            mockedMapper.Verify(x => x.MapObject<ProjectDTO>(It.Is<Project>(p => p == project && project.ProjectTasks.All(t => t.IsDeleted == false))), Times.Once);
        }

        [Test]
        public void ReturnMappedProject()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedProject = new Mock<ProjectDTO>();
            mockedMapper.Setup(x => x.MapObject<ProjectDTO>(It.IsAny<Project>())).Returns(mappedProject.Object);
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 1;

            var result = projectService.GetById(id);

            Assert.AreSame(mappedProject.Object, result);
        }
    }
}
