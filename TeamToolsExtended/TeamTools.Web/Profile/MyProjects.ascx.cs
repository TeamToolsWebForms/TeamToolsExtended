using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using TeamTools.Logic.Mvp.Profile.Home;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomeProjectsPresenter))]
    public partial class MyProjects : MvpUserControl<ProfileHomeViewModel>, IProfileHomeProjectsView
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