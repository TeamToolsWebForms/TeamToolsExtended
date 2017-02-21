using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Account.ResetPassword.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Account.ResetPassword;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Account.ResetPassword.ResetPasswordPresenterTests
{
    [TestFixture]
    public class View_GetUser_Should
    {
        [Test]
        public void CallUserService_Once()
        {
            var mockedView = new Mock<IResetPasswordView>();
            var viewModel = new ResetPasswordViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
           
            var presenter = new ResetPasswordPresenter(mockedView.Object, mockedUserService.Object);
            string username = "test";

            mockedView.Raise(x => x.GetUser += null, new ResetPasswordEventArgs(username));

            mockedUserService.Verify(x => x.GetByUsername(It.Is<string>(u => u == username)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_Correct()
        {
            var mockedView = new Mock<IResetPasswordView>();
            var viewModel = new ResetPasswordViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var userDTO = new UserDTO();
            mockedUserService.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(userDTO);

            var presenter = new ResetPasswordPresenter(mockedView.Object, mockedUserService.Object);
            string username = "test";

            mockedView.Raise(x => x.GetUser += null, new ResetPasswordEventArgs(username));

            Assert.AreSame(mockedView.Object.Model.User, userDTO);
        }
    }
}
