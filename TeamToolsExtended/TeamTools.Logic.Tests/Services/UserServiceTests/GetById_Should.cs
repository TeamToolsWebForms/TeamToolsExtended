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
    public class GetById_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
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
            string userId = "12321-2112";

            userService.GetById(userId);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == userId)), Times.Once);
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

            userService.GetById(userId);

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
            string userId = "12321-2112";

            var result = userService.GetById(userId);

            Assert.AreSame(userDTO, result);
        }
    }
}
