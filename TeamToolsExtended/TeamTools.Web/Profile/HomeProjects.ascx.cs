using System;
using System.Web.UI;
using TeamTools.Mvp.Profile.Home;
using TeamTools.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(IProfileHomeProjectsPresenter))]
    public partial class HomeProjects : MvpUserControl<ProfileHomeViewModel>, IProfileHomeProjectsView
    {
        public event EventHandler<ProfileHomeEventArgs> LoadUserWithPersonalProjects;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();
            this.LoadUserWithPersonalProjects?.Invoke(this, new ProfileHomeEventArgs(userId, username));

            this.ProfileProjects.DataSource = this.Model.User.Projects;
            this.ProfileProjects.DataBind();
        }
    }
}