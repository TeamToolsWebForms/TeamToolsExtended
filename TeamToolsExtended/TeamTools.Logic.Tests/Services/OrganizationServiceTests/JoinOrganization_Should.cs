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
using System.Linq.Expressions;

namespace TeamTools.Logic.Tests.Services.OrganizationServiceTests
{
    [TestFixture]
    public class JoinOrganization_Should
    {
        [Test]
        public void CallOrganizationRepository_GetByIdOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            int id = 15;
            string username = "test";

            organizationService.JoinOrganization(id, username);

            mockedOrganizationRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallUserRepository_AllOnce()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            int id = 15;
            string username = "test";

            organizationService.JoinOrganization(id, username);

            mockedUserRepository.Verify(x => x.All(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedOrganizationRepository = new Mock<IRepository<Organization>>();
            var organization = new Organization();
            mockedOrganizationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(organization);
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
            int id = 15;
            string username = "test";

            organizationService.JoinOrganization(id, username);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
