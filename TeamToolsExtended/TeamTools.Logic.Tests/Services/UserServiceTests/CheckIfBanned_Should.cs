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

namespace TeamTools.Logic.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class CheckIfBanned_Should
    {
        [Test]
        public void ReturnTrue_IfIsInRoleBanned()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var role = new IdentityUserRole() { RoleId = "2" };
            var user = new User();
            user.Roles.Add(role);
            var users = new List<User>() { user };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var roles = new List<IdentityUserRole>() { role };
            mockedRoleRepository.Setup(x => x.All(It.IsAny<Expression<Func<IdentityUserRole, bool>>>())).Returns(roles);
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

            var result = userService.CheckIfBanned(username);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_IfIsNotInRoleBanned()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var role = new IdentityUserRole() { RoleId = "2" };
            var user = new User();
            var users = new List<User>() { user };
            mockedUserRepository.Setup(x => x.All(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedRoleRepository = new Mock<IRepository<IdentityUserRole>>();
            var roles = new List<IdentityUserRole>() { role };
            mockedRoleRepository.Setup(x => x.All(It.IsAny<Expression<Func<IdentityUserRole, bool>>>())).Returns(roles);
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

            var result = userService.CheckIfBanned(username);

            Assert.IsFalse(result);
        }
    }
}
