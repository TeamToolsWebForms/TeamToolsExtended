using System;
using System.Linq;
using System.Web.UI;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomeProjectsPresenter))]
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

        protected void SortInitially_ServerClick(object sender, EventArgs e)
        {
            this.ProfileProjects.DataSource = this.Model.User.Projects.OrderBy(x => x.Id).ToList();
            this.ProfileProjects.DataBind();
        }

        protected void SortByName_ServerClick(object sender, EventArgs e)
        {
            this.ProfileProjects.DataSource = this.Model.User.Projects.OrderBy(x => x.Title).ToList();
            this.ProfileProjects.DataBind();
        }
    }
}