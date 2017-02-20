using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
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

            userService.GetAll();

            mockedUserRepository.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnCorrectResultCount()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var users = new List<User>()
            {
                new User() { UserName = "John" },
                new User() { UserName = "Smith" },
                new User() { UserName = "Loyd" }
            };
            mockedUserRepository.Setup(x => x.All()).Returns(users);
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

            var result = userService.GetAll();

            Assert.AreEqual(users.Count, result.Count);
        }
    }
}
