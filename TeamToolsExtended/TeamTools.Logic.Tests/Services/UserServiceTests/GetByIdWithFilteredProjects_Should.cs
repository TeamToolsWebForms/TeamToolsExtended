using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using System.Linq.Expressions;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetByIdWithFilteredProjects_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
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
            string userId = "12321-2112";
            string username = "test";

            userService.GetByIdWithFilteredProjects(userId, username);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void CallProjectRepository_AllOnce()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
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
            string userId = "12321-2112";
            string username = "test";

            userService.GetByIdWithFilteredProjects(userId, username);

            mockedProjectRepository.Verify(x => x.All(It.IsAny<Expression<Func<Project, bool>>>()), Times.Once);
        }

        [Test]
        public void CallMapperService_Once()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
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
            string userId = "12321-2112";
            string username = "test";

            userService.GetByIdWithFilteredProjects(userId, username);

            mockedMapper.Verify(x => x.MapObject<UserDTO>(It.Is<User>(u => u == user)), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var mockedMapper = new Mock<IMapperService>();
            var userDTO = new UserDTO();
            mockedMapper.Setup(x => x.MapObject<UserDTO>(It.IsAny<User>())).Returns(userDTO);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(
                mockedUserRepository.Object,
                mockedProjectRepository.Object,
                mockedOrganizationRepository.Object,
                mockedRoleRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);
            string userId = "12321-2112";
            string username = "test";

            var result = userService.GetByIdWithFilteredProjects(userId, username);

            Assert.AreSame(userDTO, result);
        }
    }
}
