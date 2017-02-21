using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsMain.OrganizationDetailsPresenterTests
{
    [TestFixture]
    public class View_LeaveOrganization_Should
    {
        [Test]
        public void CallOrganizationService_Once()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var viewModel = new OrganizationDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedJsonnService = new Mock<IJsonService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                mockedOrganizationService.Object);
            string userId = "dasfdas-dsafdsa";
            int orgId = 12;

            mockedView.Raise(x => x.LeaveOrganization += null, new OrganizationDetailsEventArgs(userId, orgId));

            mockedOrganizationService.Verify(x => x.RemoveUserFromOrganization(It.Is<string>(u => u == userId), It.Is<int>(i => i == orgId)), Times.Once);
        }
    }
}
