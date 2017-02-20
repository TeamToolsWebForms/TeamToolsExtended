using System.Linq;
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
    public class GetUnsignedOrgUsersToProject_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            int orgId = 123;
            int projectId = 12;

            projectService.GetUnsignedOrgUsersToProject(projectId, orgId);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == orgId)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            int orgId = 123;
            int projectId = 12;

            projectService.GetUnsignedOrgUsersToProject(projectId, orgId);

            mockedProjectRepository.Verify(x => x.GetById(It.Is<int>(i => i == projectId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            var projectUser = new User() { UserName = "John" };
            project.Users.Add(projectUser);
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            organization.Users.Add(projectUser);
            organization.Users.Add(new User() { UserName = "Smith" });
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectFactory = new Mock<IProjectFactory>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedJsonService = new Mock<IJsonService>();
            var expectedUsernames = organization.Users.Except(project.Users).Select(x => x.UserName).ToList();
            mockedJsonService.Setup(x => x.GetAsJson(It.IsAny<object>())).Returns(expectedUsernames[0]);

            var projectService = new ProjectService(
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedUnitOfWork.Object,
                mockedProjectFactory.Object,
                mockedMapper.Object,
                mockedJsonService.Object);
            int orgId = 123;
            int projectId = 12;

            var result = projectService.GetUnsignedOrgUsersToProject(projectId, orgId);

            Assert.AreEqual("Smith", result);
        }
    }
}
