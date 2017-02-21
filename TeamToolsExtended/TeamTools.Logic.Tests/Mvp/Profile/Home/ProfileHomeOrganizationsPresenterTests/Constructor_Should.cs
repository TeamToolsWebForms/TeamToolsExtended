using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.Home.ProfileHomeOrganizationsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IProfileHomeOrganizationsView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileHomeOrganizationsPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfProfileHomeOrganizationsPresenter_Correct()
        {
            var mockedView = new Mock<IProfileHomeOrganizationsView>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new ProfileHomeOrganizationsPresenter(
                mockedView.Object,
                mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProfileHomeOrganizationsPresenter>(presenter);
        }
    }
}
