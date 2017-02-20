using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.FileServiceTests
{
    [TestFixture]
    public class UpdateDocument_Should
    {
        [Test]
        public void CallOrganizationRepository_Once()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrg = new Mock<Organization>();
            mockedOrganizationRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrg.Object);
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedOrgLogo = new Mock<OrganizationLogo>();
            mockedOrganizationLogoRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrgLogo.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);

            byte[] content = new byte[] { 12, 33, 123 };
            int id = 114;

            fileService.UpdateDocument(content, id);

            mockedOrganizationRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallOrganizationLogoRepository_GetByIdOnce()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrg = new Mock<Organization>();
            mockedOrganizationRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrg.Object);
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedOrgLogo = new Mock<OrganizationLogo>();
            mockedOrganizationLogoRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrgLogo.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);

            byte[] content = new byte[] { 12, 33, 123 };
            int id = 114;

            fileService.UpdateDocument(content, id);

            mockedOrganizationLogoRepo.Verify(x => x.GetById(It.Is<int>(i => i == mockedOrg.Object.Id)), Times.Once);
        }

        [Test]
        public void CallImageHelper_Once()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrg = new Mock<Organization>();
            mockedOrganizationRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrg.Object);
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedOrgLogo = new Mock<OrganizationLogo>();
            mockedOrganizationLogoRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrgLogo.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);

            byte[] content = new byte[] { 12, 33, 123 };
            int id = 114;

            fileService.UpdateDocument(content, id);

            mockedImageHelper.Verify(x => x.ByteArrayToImageUrl(It.Is<byte[]>(a => a == mockedOrgLogo.Object.Image)), Times.Once);
        }

        [Test]
        public void CallOrganizationLogoRepository_UpdateOnce()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrg = new Mock<Organization>();
            mockedOrganizationRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrg.Object);
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedOrgLogo = new Mock<OrganizationLogo>();
            mockedOrganizationLogoRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrgLogo.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);

            byte[] content = new byte[] { 12, 33, 123 };
            int id = 114;

            fileService.UpdateDocument(content, id);

            mockedOrganizationLogoRepo.Verify(x => x.Update(It.Is<OrganizationLogo>(l => l == mockedOrgLogo.Object)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrg = new Mock<Organization>();
            mockedOrganizationRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrg.Object);
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedOrgLogo = new Mock<OrganizationLogo>();
            mockedOrganizationLogoRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedOrgLogo.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);

            byte[] content = new byte[] { 12, 33, 123 };
            int id = 114;

            fileService.UpdateDocument(content, id);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
