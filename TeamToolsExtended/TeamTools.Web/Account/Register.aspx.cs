using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TeamTools.Authentication;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Account.Register;
using TeamTools.Logic.Mvp.Account.Register.Contracts;
using WebFormsMvp;
using System.Web.UI;

namespace TeamTools.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        private const string DefaultUserLogoPath = "~/Images/default-user.jpg";

        public event EventHandler<RegisterEventArgs> GetUser;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            this.GetUser?.Invoke(sender, new RegisterEventArgs(
                this.Email.Text,
                this.Email.Text,
                this.FirstName.Text,
                this.LastName.Text,
                this.GenderList.SelectedValue,
                HttpContext.Current.Server.MapPath(DefaultUserLogoPath)));

            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = this.Context.GetOwinContext().Get<ApplicationSignInManager>();

            IdentityResult result = manager.Create(this.Model.User, Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn(this.Model.User, isPersistent: false, rememberBrowser: true);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "registerError();", true);
            }
        }
    }
}