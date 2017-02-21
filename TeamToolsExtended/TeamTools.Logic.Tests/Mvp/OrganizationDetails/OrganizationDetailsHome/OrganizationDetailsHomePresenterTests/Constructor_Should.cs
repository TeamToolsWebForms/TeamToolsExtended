using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsHome.OrganizationDetailsHomePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenOrganizationService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsHomeView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsHomePresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Organization Service"));
        }

        [Test]
        public void ReturnInstanceOfOrganizationDetailsHomePresenter_Correct()
        {
            var mockedView = new Mock<IOrganizationDetailsHomeView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsHomePresenter(mockedView.Object, mockedOrganizationService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<OrganizationDetailsHomePresenter>(presenter);
        }
    }
}
