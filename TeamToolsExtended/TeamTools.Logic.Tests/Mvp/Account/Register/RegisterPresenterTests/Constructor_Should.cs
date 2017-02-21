using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Account.Register;
using TeamTools.Logic.Mvp.Account.Register.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Account.Register.RegisterPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();
            
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(
                mockedView.Object,
                null,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ThrowsWhenUserFactory_IsNull()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                null,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("User Factory"));
        }

        [Test]
        public void ThrowsWhenUserFactoryLogo_IsNull()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedFileService = new Mock<IFileService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                null,
                mockedFileService.Object,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("UserLogo Factory"));
        }

        [Test]
        public void ThrowsWhenFileService_IsNull()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                null,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("File Service"));
        }

        [Test]
        public void ThrowsWhenImageHelper_IsNull()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedUserLogoFactory = new Mock<IUserLogoFactory>();
            var mockedFileService = new Mock<IFileService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedUserFactory.Object,
                mockedUserLogoFactory.Object,
                mockedFileService.Object,
                null));
            Assert.That(ex.Message.Contains("Image Helper"));
        }

        [Test]
        public void ReturnInstanceOfRegisterPresenter_Correct()
        {
            var mockedView = new Mock<IRegisterView>();
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

            Assert.IsNotNull(registerPresenter);
            Assert.IsInstanceOf<RegisterPresenter>(registerPresenter);
        }
    }
}
