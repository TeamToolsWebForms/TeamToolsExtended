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
    public class Update_Should
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
            string title = "test title";

            projectService.Update(id, title);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_UpdateWithUpdatedProjectOnce()
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
            string title = "test title";

            projectService.Update(id, title);

            mockedProjectRepository.Verify(x => x.Update(It.Is<Project>(p => p == project && project.Title == title)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
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
            string title = "test title";

            projectService.Update(id, title);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
