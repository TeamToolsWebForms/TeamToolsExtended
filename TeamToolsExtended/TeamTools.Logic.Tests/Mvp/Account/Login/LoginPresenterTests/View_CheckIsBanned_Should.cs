using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Account.Login.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Account.Login;

namespace TeamTools.Logic.Tests.Mvp.Account.Login.LoginPresenterTests
{
    [TestFixture]
    public class View_CheckIsBanned_Should
    {
        [Test]
        public void CallUserService_Once()
        {
            var mockedView = new Mock<ILoginView>();
            var viewModel = new LoginViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();

            var presenter = new LoginPresenter(mockedView.Object, mockedUserService.Object);
            string username = "test";

            mockedView.Raise(x => x.CheckIsBanned += null, new LoginEventArgs(username));

            mockedUserService.Verify(x => x.CheckIfBanned(It.Is<string>(u => u == username)));
        }

        [Test]
        public void SetValueToModel()
        {
            var mockedView = new Mock<ILoginView>();
            var viewModel = new LoginViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.CheckIfBanned(It.IsAny<string>())).Returns(true);

            var presenter = new LoginPresenter(mockedView.Object, mockedUserService.Object);
            string username = "test";

            mockedView.Raise(x => x.CheckIsBanned += null, new LoginEventArgs(username));

            Assert.IsTrue(mockedView.Object.Model.IsBanned);
        }
    }
}
