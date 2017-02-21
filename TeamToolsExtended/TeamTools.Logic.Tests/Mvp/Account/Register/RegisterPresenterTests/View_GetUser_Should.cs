using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Account.Register.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Account.Register;
using System.Drawing;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Mvp.Account.Register.RegisterPresenterTests
{
    [TestFixture]
    public class View_GetUser_Should
    {
        [Test]
        public void CallImageHelper_GetImageOnce()
        {
            var mockedView = new Mock<IRegisterView>();
            var viewModel = new RegisterViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var registerPresenter = new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object);

            string username = "test";
            string email = "test";
            string firstName = "some";
            string lastName = "other";
            string gender = "male";
            string userLogoPath = "somepath";

            mockedView.Raise(x => x.GetUser += null, new RegisterEventArgs(
                username,
                email,
                firstName,
                lastName,
                gender,
                userLogoPath));

            mockedImageHelper.Verify(x => x.GetImage(It.Is<string>(p => p == userLogoPath)), Times.Once);
        }

        [Test]
        public void CallUserLogoFactory_Once()
        {
            var mockedView = new Mock<IRegisterView>();
            var viewModel = new RegisterViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            byte[] convertedContent = new byte[] { 12, 213, 43 };
            mockedImageHelper.Setup(x => x.ImageToByteArray(It.IsAny<Image>())).Returns(convertedContent);

            var registerPresenter = new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object);

            string username = "test";
            string email = "test";
            string firstName = "some";
            string lastName = "other";
            string gender = "male";
            string userLogoPath = "somepath";

            mockedView.Raise(x => x.GetUser += null, new RegisterEventArgs(
                username,
                email,
                firstName,
                lastName,
                gender,
                userLogoPath));

            mockedUserLogoFactory.Verify(x => x.CreateUserLogo(It.Is<byte[]>(c => c == convertedContent)), Times.Once);
        }

        [Test]
        public void CallUserFactory_Once()
        {
            var mockedView = new Mock<IRegisterView>();
            var viewModel = new RegisterViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var userLogo = new UserLogo();
            mockedUserLogoFactory.Setup(x => x.CreateUserLogo(It.IsAny<byte[]>())).Returns(userLogo);
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var registerPresenter = new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object);

            string username = "test";
            string email = "test";
            string firstName = "some";
            string lastName = "other";
            string gender = "male";
            string userLogoPath = "somepath";

            mockedView.Raise(x => x.GetUser += null, new RegisterEventArgs(
                username,
                email,
                firstName,
                lastName,
                gender,
                userLogoPath));

            mockedUserFactory
                .Verify(
                    x =>
                        x.CreateUser(
                            It.Is<string>(u => u == username),
                            It.Is<string>(e => e == email),
                            It.Is<string>(f => f == firstName),
                            It.Is<string>(l => l == lastName),
                            It.Is<string>(g => g == gender),
                            It.Is<UserLogo>(p => p == userLogo)), Times.Once);
        }

        [Test]
        public void SetViewModelUser_CorrectValue()
        {
            var mockedView = new Mock<IRegisterView>();
            var viewModel = new RegisterViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var user = new User();
            mockedUserFactory.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<UserLogo>())).
                Returns(user);
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var registerPresenter = new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object);

            string username = "test";
            string email = "test";
            string firstName = "some";
            string lastName = "other";
            string gender = "male";
            string userLogoPath = "somepath";

            mockedView.Raise(x => x.GetUser += null, new RegisterEventArgs(
                username,
                email,
                firstName,
                lastName,
                gender,
                userLogoPath));

            Assert.AreSame(mockedView.Object.Model.User, user);
        }
    }
}
