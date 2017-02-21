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
    public class View_CanJoinOrganization_Should
    {
        [Test]
        public void CallOrganizationService_CanUserJoinOrganizationOnce()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var viewModel = new OrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
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

            mockedView.Raise(x => x.CanJoinOrganization += null, new OrganizationsEventArgs(id, username));

            mockedOrganizationService.Verify(x => x.CanUserJoinOrganization(It.Is<int>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_Correct()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var viewModel = new OrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            mockedOrganizationService.Setup(x => x.CanUserJoinOrganization(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
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

            mockedView.Raise(x => x.CanJoinOrganization += null, new OrganizationsEventArgs(id, username));

            Assert.IsTrue(mockedView.Object.Model.CanJoinOrganization);
        }
    }
}
