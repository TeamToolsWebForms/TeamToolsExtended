using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TeamTools.Logic.Data.Models;
using TeamTools.Web.IdentityHelpers;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using TeamTools.Authentication;

namespace TeamTools.Web.Account
{
    public partial class Register : Page
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/default-user.jpg"), true);
            var converterImage = this.ImageToByteArray(image);

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new User()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Gender = GenderList.SelectedValue,
                UserLogo = new UserLogo() { Image = converterImage }
            };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}