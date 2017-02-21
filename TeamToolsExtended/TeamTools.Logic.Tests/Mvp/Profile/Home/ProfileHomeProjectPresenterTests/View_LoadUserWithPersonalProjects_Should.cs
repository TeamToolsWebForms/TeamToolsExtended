using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeProjectPresenterTests
{
    [TestFixture]
    public class View_LoadUserWithPersonalProjects_Should
    {
        [Test]
        public void CallUserService_GetByIdWithFilteredProjectsOnce()
        {
            var mockedView = new Mock<IProfileHomeProjectsView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();

            var presenter = new ProfileHomeProjectsPresenter(mockedView.Object, mockedUserService.Object);
            string id = "213-3232";
            string username = "test";

            mockedView.Raise(x => x.LoadUserWithPersonalProjects += null, new ProfileHomeEventArgs(id, username));

            mockedUserService.Verify(x => x.GetByIdWithFilteredProjects(It.Is<string>(i => i == id), It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void SetViewModelUser_Correct()
        {
            var mockedView = new Mock<IProfileHomeProjectsView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            mockedUserService.Setup(x => x.GetByIdWithFilteredProjects(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            var presenter = new ProfileHomeProjectsPresenter(mockedView.Object, mockedUserService.Object);
            string id = "213-3232";
            string username = "test";

            mockedView.Raise(x => x.LoadUserWithPersonalProjects += null, new ProfileHomeEventArgs(id, username));

            Assert.AreEqual(mockedView.Object.Model.User, user);
        }
    }
}
