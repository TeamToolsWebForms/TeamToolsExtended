using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Account.ResetPassword.Contracts;
using TeamTools.Logic.Mvp.Account.ResetPassword;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Account.ResetPassword.ResetPasswordPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IResetPasswordView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ResetPasswordPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfResetPasswordPresenter_Correct()
        {
            var mockedView = new Mock<IResetPasswordView>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new ResetPasswordPresenter(mockedView.Object, mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ResetPasswordPresenter>(presenter);
        }
    }
}
