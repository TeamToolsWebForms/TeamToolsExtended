using System.Collections.Generic;
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
    public class GetUserOrganizations_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            string id = "testId";

            organizationService.GetUserOrganizations(id);

            mockedUserRepository.Verify(x => x.GetById(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void ReturnCorrectCountOrganizations()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var mockedUserRepository = new Mock<IRepository<User>>();
            var user = new User() { Organizations = new HashSet<Organization>() { new Organization() { Name = "Fisrt" }, new Organization() { Name = "Second" } } };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedMapper = new Mock<IMapperService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var organizationService = new OrganizationService(
                mockedOrganizationRepository.Object,
                mockedUserRepository.Object,
                mockedMapper.Object,
                mockedImageHelper.Object,
                mockedUnitOfWork.Object);
            string id = "testId";

            var result = organizationService.GetUserOrganizations(id);
            
            Assert.AreEqual(user.Organizations.Count, result.Count);
        }
    }
}
