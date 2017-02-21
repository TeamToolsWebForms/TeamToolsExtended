using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsMain.OrganizationDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var mockedJsonService = new Mock<IJsonService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsPresenter(
                mockedView.Object,
                null,
                mockedJsonService.Object,
                mockedOrganizationService.Object));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ThrowsWhenJsonService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                null,
                mockedOrganizationService.Object));
            Assert.That(ex.Message.Contains("Json Service"));
        }

        [Test]
        public void ThrowsWhenOrganizationService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedJsonnService = new Mock<IJsonService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                null));
            Assert.That(ex.Message.Contains("Organization Service"));
        }

        [Test]
        public void ReturnInstanceOfOrganizationDetailsPresenter_Correct()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedJsonnService = new Mock<IJsonService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                mockedOrganizationService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<OrganizationDetailsPresenter>(presenter);
        }
    }
}
