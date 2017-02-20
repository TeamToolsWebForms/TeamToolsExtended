using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.FileServiceTests
{
    [TestFixture]
    public class SaveDocument_Should
    {
        [Test]
        public void CallProjectDocumentFactoryOnce()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var doc = new Mock<ProjectDocumentDTO>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);
            string filename = "some";
            string fileExtension = ".doc";
            byte[] content = new byte[] { 1, 2 };
            int id = 12;

            fileService.SaveDocument(filename, fileExtension, content, id);

            mockedProjectDocumentFactory.Verify(x => x.CreateProjectDocument(filename, fileExtension, content, id), Times.Once);
        }

        [Test]
        public void CallMapperService_WithCreatedDocument()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var doc = new Mock<ProjectDocumentDTO>();
            mockedProjectDocumentFactory.Setup(x => x.CreateProjectDocument(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>())).Returns(doc.Object);
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);
            string filename = "some";
            string fileExtension = ".doc";
            byte[] content = new byte[] { 1, 2 };
            int id = 12;

            fileService.SaveDocument(filename, fileExtension, content, id);

            mockedMapper.Verify(x => x.MapObject<ProjectDocument>(It.Is<ProjectDocumentDTO>(d => d == doc.Object)), Times.Once);
        }

        [Test]
        public void CallRepository_WithMappedDocument()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedDocument = new Mock<ProjectDocument>();
            mockedMapper.Setup(x => x.MapObject<ProjectDocument>(It.IsAny<ProjectDocumentDTO>())).Returns(mockedDocument.Object);
            var mockedProjectDocumentFactory = new Mock<IProjectDocumentFactory>();
            var doc = new Mock<ProjectDocumentDTO>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var fileService = new FileService(
                mockedProjectDocumentRepo.Object,
                mockedOrganizationRepo.Object,
                mockedOrganizationLogoRepo.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedProjectDocumentFactory.Object,
                mockedImageHelper.Object);
            string filename = "some";
            string fileExtension = ".doc";
            byte[] content = new byte[] { 1, 2 };
            int id = 12;

            fileService.SaveDocument(filename, fileExtension, content, id);

            mockedProjectDocumentRepo.Verify(x => x.Add(It.Is<ProjectDocument>(d => d == mockedDocument.Object)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
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
            string filename = "some";
            string fileExtension = ".doc";
            byte[] content = new byte[] { 1, 2 };
            int id = 12;

            fileService.SaveDocument(filename, fileExtension, content, id);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
