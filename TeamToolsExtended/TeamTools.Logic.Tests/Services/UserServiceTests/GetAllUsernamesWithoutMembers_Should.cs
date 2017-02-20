using System.Collections.Generic;
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
    public class GetAllUsernamesWithoutMembers_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
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
            string userId = "test";
            int orgId = 132;

            userService.GetAllUsernamesWithoutMembers(userId, orgId);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == orgId)), Times.Once);
        }

        [Test]
        public void CallUserRepository_AllOnce()
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
            string userId = "test";
            int orgId = 132;

            userService.GetAllUsernamesWithoutMembers(userId, orgId);

            mockedUserRepository.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var users = new List<User>()
            {
                new User() { UserName = "John" },
                new User() { UserName = "Smith" }
            };
            mockedUserRepository.Setup(x => x.All()).Returns(users);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            string userId = "test";
            int orgId = 132;
            var expected = new List<string>() { "John", "Smith" };

            var result = userService.GetAllUsernamesWithoutMembers(userId, orgId);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
