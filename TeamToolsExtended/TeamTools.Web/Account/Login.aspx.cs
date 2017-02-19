using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;
using TeamTools.Authentication;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Account.Login;
using TeamTools.Logic.Mvp.Account.Login.Contracts;
using WebFormsMvp;

namespace TeamTools.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginViewModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> CheckIsBanned;

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                this.CheckIsBanned?.Invoke(sender, new LoginEventArgs(this.Email.Text));

                if (this.Model.IsBanned)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "banError();", true);
                    return;
                }

                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, true, shouldLockout: false);
                
                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.Failure:
                    default:
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showErrorMessage();", true);
                        break;
                }
            }
        }
    }
}