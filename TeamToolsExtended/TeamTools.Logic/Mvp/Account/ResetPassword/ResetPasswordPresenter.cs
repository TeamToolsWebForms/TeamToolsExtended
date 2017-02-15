using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Account.ResetPassword.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.ResetPassword
{
    public class ResetPasswordPresenter : Presenter<IResetPasswordView>
    {
        private readonly IUserService userService;

        public ResetPasswordPresenter(IResetPasswordView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(view, "View").IsNull().Throw();
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.View.GetUser += View_GetUser;

            this.userService = userService;
        }

        private void View_GetUser(object sender, ResetPasswordEventArgs e)
        {
            this.View.Model.User = this.userService.GetByUsername(e.Username);
        }
    }
}
