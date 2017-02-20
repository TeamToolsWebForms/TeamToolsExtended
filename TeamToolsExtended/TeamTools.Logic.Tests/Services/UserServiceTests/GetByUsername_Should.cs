using System;
using System.Collections.Generic;
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
    public class GetByUsername_Should
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
            string username = "test";

            userService.GetByUsername(username);

            mockedUserRepository.Verify(x => x.All(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [Test]
        public void CallMapperService_Once()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User() { UserName = "test" };
            var users = new List<User>() { user };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
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
            string username = "test";

            userService.GetByUsername(username);

            mockedMapper.Verify(x => x.MapObject<UserDTO>(It.Is<User>(u => u == user)), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
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
            string username = "test";

            var result = userService.GetByUsername(username);

            Assert.AreSame(userDTO, result);
        }
    }
}
