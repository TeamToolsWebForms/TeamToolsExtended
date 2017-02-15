using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;
using TeamTools.Authentication;

namespace TeamTools.Web.Account
{
    public partial class Login : Page
    {
        protected void LogIn(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                
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