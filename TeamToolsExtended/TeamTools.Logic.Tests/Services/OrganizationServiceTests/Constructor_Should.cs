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
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.OrganizationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenOrganizationRepository_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationService(
                null,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Organization Repository"));
        }

        [Test]
        public void ThrowWhenUserRepository_IsNull()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationService(
                mockedOrganizationRepository.Object,
                null,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("User Repository"));
        }

        [Test]
        public void ThrowWhenMapperService_IsNull()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                null,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowWhenImageHelper_IsNull()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                null,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Image Helper"));
        }

        [Test]
        public void ThrowWhenUnitOfWork_IsNull()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                null));
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ReturnInstanceOfOrganizationService_Correct()
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

            Assert.IsNotNull(organizationService);
            Assert.IsInstanceOf<OrganizationService>(organizationService);
        }
    }
}
