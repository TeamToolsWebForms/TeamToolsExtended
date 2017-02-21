using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Admin.AllUsers.Contracts;
using TeamTools.Logic.Mvp.Admin.AllUsers;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Admin.AllUsers.AllUsersPresenterTests
{
    [TestFixture]
    public class View_LoadUsers_Should
    {
        [Test]
        public void CallUserService_Once()
        {
            var mockedView = new Mock<IAllUsersView>();
            var viewModel = new AllUsersViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();

            var presenter = new AllUsersPresenter(mockedView.Object, mockedUserService.Object);

            mockedView.Raise(x => x.LoadUsers += null, EventArgs.Empty);

            mockedUserService.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IAllUsersView>();
            var viewModel = new AllUsersViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedUserService = new Mock<IUserService>();
            var users = new List<UserDTO>()
            {
                new UserDTO() { UserName = "John" },
                new UserDTO() { UserName = "Smith" }
            };
            mockedUserService.Setup(x => x.GetAll()).Returns(users);

            var presenter = new AllUsersPresenter(mockedView.Object, mockedUserService.Object);

            mockedView.Raise(x => x.LoadUsers += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(mockedView.Object.Model.Users, users);
        }
    }
}
