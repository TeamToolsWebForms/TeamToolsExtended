using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.ProjectServiceTests
{
    [TestFixture]
    public class GetByIdSearchedDocuments_Should
    {
        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedProject = new ProjectDTO();
            mappedProject.ProjectDocuments = new List<ProjectDocumentDTO>();
            mockedMapper.Setup(x => x.MapObject<ProjectDTO>(It.IsAny<Project>())).Returns(mappedProject);
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 1;
            string pattern = "some pattern";

            projectService.GetByIdSearchedDocuments(id, pattern);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallMapperService_WithFoundProjectOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedProject = new ProjectDTO();
            mappedProject.ProjectDocuments = new List<ProjectDocumentDTO>();
            mockedMapper.Setup(x => x.MapObject<ProjectDTO>(It.IsAny<Project>())).Returns(mappedProject);
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 1;
            string pattern = "some pattern";

            projectService.GetByIdSearchedDocuments(id, pattern);

            mockedMapper.Verify(x => x.MapObject<ProjectDTO>(It.Is<Project>(p => p == project)), Times.Once);
        }

        [Test]
        public void ReturnCorrectProjectDocuments()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedProject = new ProjectDTO();
            mappedProject.ProjectDocuments = new List<ProjectDocumentDTO>()
            {
                new ProjectDocumentDTO() { FileName = "some" },
                new ProjectDocumentDTO() { FileName = "someone" }
            };

            mockedMapper.Setup(x => x.MapObject<ProjectDTO>(It.IsAny<Project>())).Returns(mappedProject);
            var mockedJsonService = new Mock<IJsonService>();

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int id = 1;
            string pattern = "some pattern";

            var result = projectService.GetByIdSearchedDocuments(id, pattern);

            Assert.That(result.ProjectDocuments.All(d => d.FileName.Contains(pattern)));
        }
    }
}
