using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Organizations.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Organizations;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;

namespace TeamTools.Logic.Tests.Mvp.Organizations.OrganizationsPresenterTests
{
    [TestFixture]
    public class View_JoinOrganization_Should
    {
        [Test]
        public void CallOrganizationService_JoinOrganizationOnce()
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
            int id = 214;
            string username = "test";

            mockedView.Raise(x => x.JoinOrganization += null, new OrganizationsEventArgs(id, username));

            mockedOrganizationService.Verify(x => x.JoinOrganization(It.Is<int>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }
    }
}
