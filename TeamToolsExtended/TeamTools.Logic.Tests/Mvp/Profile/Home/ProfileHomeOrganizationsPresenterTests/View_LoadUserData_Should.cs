using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeOrganizationsPresenterTests
{
    [TestFixture]
    public class View_LoadUserData_Should
    {
        [Test]
        public void CallUserService_GetByIdOnce()
        {
            var mockedView = new Mock<IProfileHomeOrganizationsView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();

            var presenter = new ProfileHomeOrganizationsPresenter(
                mockedView.Object,
                mockedUserService.Object);
            string username = "test";
            string userId = "some-id";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(userId, username));

            mockedUserService.Verify(x => x.GetById(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IProfileHomeOrganizationsView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            mockedUserService.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);

            var presenter = new ProfileHomeOrganizationsPresenter(
                mockedView.Object,
                mockedUserService.Object);
            string username = "test";
            string userId = "some-id";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(userId, username));

            Assert.AreSame(mockedView.Object.Model.User, user);
        }
    }
}
