using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsMain.OrganizationDetailsPresenterTests
{
    [TestFixture]
    public class View_CheckIfUserPersistInOrganization_Should
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
            int id = 12;
            string username = "test";

            mockedView.Raise(x => x.CheckIfUserPersistInOrganization += null, new OrganizationDetailsEventArgs(id, username));

            mockedOrganizationService.Verify(x => x.CanUserJoinOrganization(It.Is<int>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_ValueCorrect()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var viewModel = new OrganizationDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedJsonnService = new Mock<IJsonService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            mockedOrganizationService.Setup(x => x.CanUserJoinOrganization(It.IsAny<int>(), It.IsAny<string>())).Returns(true);

            var presenter = new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                mockedOrganizationService.Object);
            int id = 12;
            string username = "test";

            mockedView.Raise(x => x.CheckIfUserPersistInOrganization += null, new OrganizationDetailsEventArgs(id, username));

            Assert.IsTrue(mockedView.Object.Model.CanVisitOrganizationDetails);
        }
    }
}
