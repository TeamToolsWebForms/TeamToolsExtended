using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Organizations.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Organizations;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Organizations.OrganizationsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenOrganizationService_IsNull()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationsPresenter(
                mockedView.Object,
                null,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("Organization Service"));
        }

        [Test]
        public void ThrowsWhenOrganizationFactory_IsNull()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                null,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("Organization Factory"));
        }

        [Test]
        public void ThrowsWhenOrganizationLogoFactory_IsNull()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                null,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("OrganizationLogo Factory"));
        }

        [Test]
        public void ThrowsWhenOImageHelper_IsNull()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                null));
            Assert.That(ex.Message.Contains("Image Helper"));
        }

        [Test]
        public void ReturnInstanceOfOrganizationsPresenter_Correct()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<OrganizationsPresenter>(presenter);
        }
    }
}
