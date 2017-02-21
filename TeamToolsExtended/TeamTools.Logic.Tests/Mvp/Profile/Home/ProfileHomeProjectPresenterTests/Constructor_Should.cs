using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeProjectPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IProfileHomeProjectsView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomeProjectsPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomeProjectsPresenter_Correct()
        {
            var mockedView = new Mock<IProfileHomeProjectsView>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new ProfileHomeProjectsPresenter(mockedView.Object, mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomeProjectsPresenter>(presenter);
        }
    }
}
