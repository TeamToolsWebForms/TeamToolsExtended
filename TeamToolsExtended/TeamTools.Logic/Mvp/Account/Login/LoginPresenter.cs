using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Account.Login.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        private readonly IUserService userService;

        public LoginPresenter(ILoginView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.View.CheckIsBanned += this.View_CheckIsBanned;

            this.userService = userService;
        }

        private void View_CheckIsBanned(object sender, LoginEventArgs e)
        {
            this.View.Model.IsBanned = this.userService.CheckIfBanned(e.Username);
        }
    }
}
