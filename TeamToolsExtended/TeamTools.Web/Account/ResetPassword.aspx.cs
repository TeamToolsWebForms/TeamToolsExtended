using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TeamTools.Authentication;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Account.ResetPassword;
using TeamTools.Logic.Mvp.Account.ResetPassword.Contracts;
using WebFormsMvp;

namespace TeamTools.Web.Account
{
    [PresenterBinding(typeof(ResetPasswordPresenter))]
    public partial class ResetPassword : MvpPage<ResetPasswordViewModel>, IResetPasswordView
    {
        public event EventHandler<ResetPasswordEventArgs> GetUser;

        protected void Reset_Click(object sender, EventArgs e)
        {
            this.GetUser?.Invoke(sender, new ResetPasswordEventArgs(this.Email.Text));
            
            if (this.Model.User == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "noUser();", true);
                return;
            }

            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string token = manager.GeneratePasswordResetToken(this.Model.User.Id);

            if (token != null)
            {
                var user = manager.FindByName(this.Email.Text);
                if (user == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "noUser();", true);
                    return;
                }
                
                var result = manager.ResetPassword(user.Id, token, this.Password.Text);
                if (result.Succeeded)
                {
                    this.Response.Redirect("~/Account/Login");
                    return;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "internalError();", true);
                return;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "internalError();", true);
        }
    }
}