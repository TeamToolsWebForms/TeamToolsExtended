using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserRepository_IsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                null,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("User Repository"));
        }

        [Test]
        public void ThrowsWhenProjectRepository_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                null,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Project Repository"));
        }

        [Test]
        public void ThrowsWhenOrganizationRepository_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                null,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Organization Repository"));
        }

        [Test]
        public void ThrowsWhenRoleRepository_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                null,
                mockedMapper.Object,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Role Repository"));
        }

        [Test]
        public void ThrowsWhenMapperService_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                null,
                mockedUnitOfWork.Object));
            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhenUnitOfWork_IsNull()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                null));
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ReturnInstanceOfUserService_Correct()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);

            Assert.IsNotNull(userService);
            Assert.IsInstanceOf<UserService>(userService);
        }
    }
}
