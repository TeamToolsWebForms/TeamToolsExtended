using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsMain.OrganizationDetailsPresenterTests
{
    [TestFixture]
    public class View_LoadAllUsersWithoutCurrentMembers_Should
    {
        [Test]
        public void CallUserService_Once()
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

            mockedView.Raise(x => x.LoadAllUsersWithoutCurrentMembers += null, new OrganizationDetailsEventArgs(userId, orgId));

            mockedUserService.Verify(x => x.GetAllUsernamesWithoutMembers(It.Is<string>(u => u == userId), It.Is<int>(i => i == orgId)), Times.Once);
        }

        [Test]
        public void CallJsonService_Once()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var viewModel = new OrganizationDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var usernames = new List<string>()
            {
                "John",
                "Smith"
            };
            mockedUserService.Setup(x => x.GetAllUsernamesWithoutMembers(It.IsAny<string>(), It.IsAny<int>())).Returns(usernames);

            var mockedJsonnService = new Mock<IJsonService>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                mockedOrganizationService.Object);
            string userId = "dasfdas-dsafdsa";
            int orgId = 12;

            mockedView.Raise(x => x.LoadAllUsersWithoutCurrentMembers += null, new OrganizationDetailsEventArgs(userId, orgId));

            mockedJsonnService.Verify(x => x.GetAsJson(It.Is<object>(o => o == usernames)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IOrganizationDetailsView>();
            var viewModel = new OrganizationDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedJsonnService = new Mock<IJsonService>();
            string usernamesJson = "[\"John\",\"Smith\"]";
            mockedJsonnService.Setup(x => x.GetAsJson(It.IsAny<object>())).Returns(usernamesJson);
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedJsonnService.Object,
                mockedOrganizationService.Object);
            string userId = "dasfdas-dsafdsa";
            int orgId = 12;

            mockedView.Raise(x => x.LoadAllUsersWithoutCurrentMembers += null, new OrganizationDetailsEventArgs(userId, orgId));

            Assert.AreSame(mockedView.Object.Model.UsersWithoutCurrentMembersJson, usernamesJson);
        }
    }
}
