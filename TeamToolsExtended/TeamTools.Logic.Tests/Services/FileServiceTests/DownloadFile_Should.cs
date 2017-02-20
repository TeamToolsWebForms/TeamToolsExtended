using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.FileServiceTests
{
    [TestFixture]
    public class DownloadFile_Should
    {
        [Test]
        public void CallRepository_Once()
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

            int id = 12;

            fileService.DownloadFile(id);

            mockedProjectDocumentRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallMapper_WithFoundDocument()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var doc = new Mock<ProjectDocument>();
            mockedProjectDocumentRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(doc.Object);
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

            int id = 12;

            fileService.DownloadFile(id);

            mockedMapper.Verify(x => x.MapObject<ProjectDocumentDTO>(It.Is<ProjectDocument>(d => d == doc.Object)), Times.Once);
        }

        [Test]
        public void ReturnMappedProjectDocument()
        {
            var mockedProjectDocumentRepo = new Mock<IRepository<ProjectDocument>>();
            var mockedOrganizationRepo = new Mock<IRepository<Organization>>();
            var mockedOrganizationLogoRepo = new Mock<IRepository<OrganizationLogo>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mappedDoc = new Mock<ProjectDocumentDTO>();
            mockedMapper.Setup(x => x.MapObject<ProjectDocumentDTO>(It.IsAny<ProjectDocument>())).Returns(mappedDoc.Object);
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

            int id = 12;

            var result = fileService.DownloadFile(id);

            Assert.AreSame(result, mappedDoc.Object);
        }
    }
}
