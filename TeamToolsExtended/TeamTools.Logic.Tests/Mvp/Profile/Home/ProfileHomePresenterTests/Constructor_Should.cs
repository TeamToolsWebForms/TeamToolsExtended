using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomePresenter(
                mockedView.Object,
                null,
                mockedImageHelper.Object));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ThrowsWhenImageHelper_IsNull()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var mockedUserService = new Mock<IUserService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                null));
            Assert.That(ex.Message.Contains("Image Helper"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomePresenter_Correct()
        {
            var mockedView = new Mock<IProfileHomeView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new ProfileHomePresenter(
                mockedView.Object,
                mockedUserService.Object,
                mockedImageHelper.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomePresenter>(presenter);
        }
    }
}
