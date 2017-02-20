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
    public class Update_Should
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
            var userDTO = new UserDTO();

            userService.Update(userDTO);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == userDTO.Id)), Times.Once);
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
            var userDTO = new UserDTO();

            userService.Update(userDTO);

            mockedMapper.Verify(x => x.MapObject<UserLogo>(It.Is<UserLogoDTO>(l => l == userDTO.UserLogo)), Times.Once);
        }

        [Test]
        public void CallUserRepository_UpdateOnce()
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
            var userDTO = new UserDTO();

            userService.Update(userDTO);

            mockedUserRepository.Verify(x => x.Update(It.Is<User>(u => u == user)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
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
            var userDTO = new UserDTO();

            userService.Update(userDTO);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
