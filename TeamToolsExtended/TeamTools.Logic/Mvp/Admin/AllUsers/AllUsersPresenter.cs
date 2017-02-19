using Bytes2you.Validation;
using System;
using TeamTools.Logic.Mvp.Admin.AllUsers.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Admin.AllUsers
{
    public class AllUsersPresenter : Presenter<IAllUsersView>
    {
        private readonly IUserService userService;

        public AllUsersPresenter(IAllUsersView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.View.LoadUsers += this.View_LoadUsers;

            this.userService = userService;
        }

        private void View_LoadUsers(object sender, EventArgs e)
        {
            this.View.Model.Users = this.userService.GetAll();
        }
    }
}
