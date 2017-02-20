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
    public class GetById_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedOrganization = new OrganizationDTO();
            mappedOrganization.Projects = new List<ProjectDTO>();
            mappedOrganization.OrganizationLogo = new OrganizationLogoDTO();
            mockedMapper.Setup(x => x.MapObject<OrganizationDTO>(It.IsAny<Organization>())).Returns(mappedOrganization);
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int id = 15;

            organizationService.GetById(id);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallMapperService_Once()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedOrganization = new OrganizationDTO();
            mappedOrganization.Projects = new List<ProjectDTO>();
            mappedOrganization.OrganizationLogo = new OrganizationLogoDTO();
            mockedMapper.Setup(x => x.MapObject<OrganizationDTO>(It.IsAny<Organization>())).Returns(mappedOrganization);
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int id = 15;

            organizationService.GetById(id);

            mockedMapper.Verify(x => x.MapObject<OrganizationDTO>(It.Is<Organization>(o => o == organization)), Times.Once);
        }

        [Test]
        public void CallImageHelper_Once()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedOrganization = new OrganizationDTO();
            mappedOrganization.Projects = new List<ProjectDTO>();
            mappedOrganization.OrganizationLogo = new OrganizationLogoDTO();
            mockedMapper.Setup(x => x.MapObject<OrganizationDTO>(It.IsAny<Organization>())).Returns(mappedOrganization);
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int id = 15;

            organizationService.GetById(id);

            mockedImageHelper.Verify(x => x.ByteArrayToImageUrl(It.Is<byte[]>(a => a == mappedOrganization.OrganizationLogo.Image)), Times.Once);
        }

        [Test]
        public void ReturnCorrectOrganization()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedOrganization = new OrganizationDTO();
            mappedOrganization.Projects = new List<ProjectDTO>();
            mappedOrganization.OrganizationLogo = new OrganizationLogoDTO();
            mockedMapper.Setup(x => x.MapObject<OrganizationDTO>(It.IsAny<Organization>())).Returns(mappedOrganization);
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            int id = 15;

            var result = organizationService.GetById(id);

            Assert.AreSame(mappedOrganization, result);
        }
    }
}
