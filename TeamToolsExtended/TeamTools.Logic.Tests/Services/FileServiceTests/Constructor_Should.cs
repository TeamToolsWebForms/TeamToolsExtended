using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.FileServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectDocumentRepository_IsNull()
        {
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                null,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("ProjectDocument Repository"));
        }

        [Test]
        public void ThrowsWhenOrganizationRepository_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                null,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("Organization Repository"));
        }

        [Test]
        public void ThrowsWhenOrganizationLogoRepository_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                null,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("OrganizationLogo Repository"));
        }

        [Test]
        public void ThrowsWhenUnitOfWork_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                null,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("Unit of work"));
        }

        [Test]
        public void ThrowsWhenMapperService_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                null,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhenProjectDocumentFactory_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                null,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("ProjectDocument Factory"));
        }

        [Test]
        public void ThrowsWhenImageHelper_IsNull()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                null));
            Assert.That(ex.Message.Contains("Image Helper"));
        }

        [Test]
        public void ReturnInstanceOfFileService()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
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

            Assert.IsNotNull(fileService);
            Assert.IsInstanceOf<FileService>(fileService);
        }
    }
}
