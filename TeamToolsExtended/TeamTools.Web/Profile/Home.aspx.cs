using System;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Mvp.Profile.Home.Contracts;
using TeamTools.Mvp.Profile.Home;
using WebFormsMvp;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(IProfileHomePresenter))]
    public partial class Home : MvpPage<ProfileHomeViewModel>, IProfileHomeView
    {
        public event EventHandler<ProfileHomeEventArgs> LoadUserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadUserData?.Invoke(sender, new ProfileHomeEventArgs() { Id = Page.User.Identity.GetUserId() });
            
            this.ProfileImage.ImageUrl = this.Model.ImageUrl;
        }
    }
}