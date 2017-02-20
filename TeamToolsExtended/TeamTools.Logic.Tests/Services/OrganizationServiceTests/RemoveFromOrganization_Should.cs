using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.OrganizationServiceTests
{
    [TestFixture]
    public class RemoveFromOrganization_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int orgId = 15;
            string userId = "test";

            organizationService.RemoveUserFromOrganization(userId, orgId);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == orgId)), Times.Once);
        }

        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int orgId = 15;
            string userId = "test";

            organizationService.RemoveUserFromOrganization(userId, orgId);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void CallOrganizationRepository_UpdateOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int orgId = 15;
            string userId = "test";

            organizationService.RemoveUserFromOrganization(userId, orgId);

            mockedOrganizationRepository.Verify(x => x.Update(It.Is<Organization>(o => o == organization)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int orgId = 15;
            string userId = "test";

            organizationService.RemoveUserFromOrganization(userId, orgId);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
