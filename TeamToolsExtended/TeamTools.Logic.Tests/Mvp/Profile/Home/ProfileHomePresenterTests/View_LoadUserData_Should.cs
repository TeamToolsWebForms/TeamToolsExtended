using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomePresenterTests
{
    [TestFixture]
    public class View_LoadUserData_Should
    {
        [Test]
        public void CallUserService_GetByIdOnce()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            var userLogo = new UserLogoDTO();
            user.UserLogo = userLogo;
            mockedUserService.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedImageHelper.Object);
            string id = "12312-444";
            string username = "test";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(id, username));

            mockedUserService.Verify(x => x.GetById(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewModelUser_Correct()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            var userLogo = new UserLogoDTO();
            user.UserLogo = userLogo;
            mockedUserService.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedImageHelper.Object);
            string id = "12312-444";
            string username = "test";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(id, username));

            Assert.AreEqual(mockedView.Object.Model.User, user);
        }

        [Test]
        public void CallImageHelper_ByteArrayToImageUrlOnce()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            var userLogo = new UserLogoDTO();
            user.UserLogo = userLogo;
            mockedUserService.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedImageHelper.Object);
            string id = "12312-444";
            string username = "test";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(id, username));

            mockedImageHelper.Verify(x => x.ByteArrayToImageUrl(It.Is<byte[]>(a => a == user.UserLogo.Image)), Times.Once);
        }

        [Test]
        public void SetViewModelImageUrl_Correct()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var viewModel = new ProfileHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var user = new UserDTO();
            var userLogo = new UserLogoDTO();
            user.UserLogo = userLogo;
            mockedUserService.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);
            var mockedImageHelper = new Mock<IImageHelper>();
            mockedImageHelper.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("data:image/jpg;base64,");

            var presenter = new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedImageHelper.Object);
            string id = "12312-444";
            string username = "test";
            string expected = "data:image/jpg;base64,";

            mockedView.Raise(x => x.LoadUserData += null, new ProfileHomeEventArgs(id, username));

            Assert.AreEqual(expected, mockedView.Object.Model.ImageUrl);
        }
    }
}
