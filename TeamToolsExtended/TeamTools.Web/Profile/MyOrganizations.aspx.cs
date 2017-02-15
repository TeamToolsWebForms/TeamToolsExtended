using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(MyOrganizationsPresenter))]
    public partial class MyOrganizations : MvpPage<MyOrganizationsViewModel>, IMyOrganizationsView
    {
        public event EventHandler<MyOrganizationsEventArgs> LoadMyOrganizations;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = this.Page.User.Identity.GetUserId();
            this.LoadMyOrganizations?.Invoke(sender, new MyOrganizationsEventArgs(userId));

            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations;
            this.MyOrganizationsListView.DataBind();
        }
    }
}