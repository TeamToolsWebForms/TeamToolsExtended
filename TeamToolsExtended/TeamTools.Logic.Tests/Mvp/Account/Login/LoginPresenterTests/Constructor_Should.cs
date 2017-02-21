using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Account.Login;
using TeamTools.Logic.Mvp.Account.Login.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Account.Login.LoginPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<ILoginView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new LoginPresenter(mockedView.Object, null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfLoginPresenter_Correct()
        {
            var mockedView = new Mock<ILoginView>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new LoginPresenter(mockedView.Object, mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<LoginPresenter>(presenter);
        }
    }
}
