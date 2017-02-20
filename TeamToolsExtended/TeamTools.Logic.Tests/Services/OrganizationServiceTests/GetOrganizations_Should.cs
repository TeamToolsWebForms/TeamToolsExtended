using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.OrganizationServiceTests
{
    [TestFixture]
    public class GetOrganizations_Should
    {
        [Test]
        public void CallOrganizationRepository_AllOnce()
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

            organizationService.GetOrganizations();

            mockedOrganizationRepository.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnOrganizationCollection()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organizations = new List<Organization>()
            {
                new Organization(),
                new Organization()
            };
            mockedOrganizationRepository.Setup(x => x.All()).Returns(organizations);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedOrganization = new Mock<OrganizationDTO>();
            mockedMapper.Setup(x => x.MapObject<OrganizationDTO>(It.IsAny<Organization>())).Returns(mockedOrganization.Object);
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);

            var result = organizationService.GetOrganizations();

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(OrganizationDTO));
            Assert.AreEqual(organizations.Count, result.Count);
        }
    }
}
