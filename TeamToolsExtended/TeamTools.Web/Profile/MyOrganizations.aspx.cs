using System;
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
        private const string DefaultOrganizationLogoPath = "~/Images/default-organization.png";
    
        public event EventHandler<OrganizationsEventArgs> LoadMyOrganizations;
        public event EventHandler<OrganizationsEventArgs> SaveOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = this.Page.User.Identity.GetUserId();
            this.LoadMyOrganizations?.Invoke(sender, new OrganizationsEventArgs(userId));

            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations;
            this.MyOrganizationsListView.DataBind();
        }

        protected void closeBtn_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeCreatePanel();", true);
        }
        
        protected void saveOrganizationBtn_Click(object sender, EventArgs e)
        {
            string name = this.OrganizationName.Text;
            if (name == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "requiredName();", true);
            }

            string description = this.organizationDesc.InnerText;
            if (description == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "requiredDescription();", true);
            }

            string userId = this.Page.User.Identity.GetUserId();
            string username = this.Page.User.Identity.GetUserName();
            
            string defaultPath = HttpContext.Current.Server.MapPath(DefaultOrganizationLogoPath);

            this.SaveOrganization?.Invoke(sender, new OrganizationsEventArgs(userId, name, description, username, defaultPath));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "saveOrganization();", true);
            
            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations;
            this.MyOrganizationsListView.DataBind();
        }

        protected void showCreatePanel_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showCreatePanel();", true);
        }

        protected void SortInitially_ServerClick(object sender, EventArgs e)
        {
            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations.OrderBy(x => x.Id).ToList();
            this.MyOrganizationsListView.DataBind();
        }

        protected void SortByName_ServerClick(object sender, EventArgs e)
        {
            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations.OrderBy(x => x.Name).ToList();
            this.MyOrganizationsListView.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string pattern = this.SearchOrganizations.Text.ToLower();
            this.MyOrganizationsListView.DataSource = this.Model.MyOrganizations.Where(x => x.Name.ToLower().Contains(pattern)).ToList();
            this.MyOrganizationsListView.DataBind();
        }
    }
}