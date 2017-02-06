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
    [PresenterBinding(typeof(ProfileHomeOrganizationsPresenter))]
    public partial class HomeOrganizations : MvpUserControl<ProfileHomeViewModel>, IProfileHomeOrganizationsView
    {
        public event EventHandler<ProfileHomeEventArgs> LoadUserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();
            this.LoadUserData?.Invoke(sender, new ProfileHomeEventArgs(userId, username));

            this.ProfileOrganizations.DataSource = this.Model.User.Organizations;
            this.ProfileOrganizations.DataBind();
        }

        protected void SortByName_Click(object sender, EventArgs e)
        {
            // check if work properly
            this.ProfileOrganizations.DataSource = this.Model.User.Organizations.OrderBy(o => o.Name).ToList();
            this.ProfileOrganizations.DataBind();
        }
    }
}