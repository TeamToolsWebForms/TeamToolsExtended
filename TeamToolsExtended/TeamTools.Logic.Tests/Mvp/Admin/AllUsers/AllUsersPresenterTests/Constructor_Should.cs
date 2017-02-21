using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Admin.AllUsers.Contracts;
using TeamTools.Logic.Mvp.Admin.AllUsers;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Admin.AllUsers.AllUsersPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IAllUsersView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new AllUsersPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfAllUsersPresenter_Correct()
        {
            var mockedView = new Mock<IAllUsersView>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new AllUsersPresenter(mockedView.Object, mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<AllUsersPresenter>(presenter);
        }
    }
}
