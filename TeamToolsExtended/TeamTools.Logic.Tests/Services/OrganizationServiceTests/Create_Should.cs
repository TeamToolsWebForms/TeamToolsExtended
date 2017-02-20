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
    public class Create_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string id = "testId";
            var organization = new Organization();

            organizationService.Create(organization, id);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallOrganizationRepository_AddOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string id = "testId";
            var organization = new Organization();

            organizationService.Create(organization, id);

            mockedOrganizationRepository.Verify(x => x.Add(It.Is<Organization>(o => o == organization)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
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
            string id = "testId";
            var organization = new Organization();

            organizationService.Create(organization, id);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
