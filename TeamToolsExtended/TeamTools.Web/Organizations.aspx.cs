using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Organizations;
using TeamTools.Logic.Mvp.Organizations.Contracts;
using WebFormsMvp;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using TeamTools.Logic.DTO;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(OrganizationsPresenter))]
    public partial class Organizations : MvpPage<OrganizationsViewModel>, IOrganizationsView
    {
        private const string DefaultOrganizationLogoPath = "~/Images/default-organization.png";

        public event EventHandler<OrganizationsEventArgs> LoadMyOrganizations;
        public event EventHandler<OrganizationsEventArgs> SaveOrganization;
        public event EventHandler<OrganizationsEventArgs> JoinOrganization;
        public event EventHandler<OrganizationsEventArgs> CanJoinOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadMyOrganizations?.Invoke(sender, null);

            this.OrganizationsListView.DataSource = this.Model.Organizations;
            this.OrganizationsListView.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string pattern = this.SearchOrganizations.Text.ToLower();
            this.OrganizationsListView.DataSource = this.Model.Organizations.Where(x => x.Name.ToLower().Contains(pattern)).ToList();
            this.OrganizationsListView.DataBind();
        }

        protected void showCreatePanel_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showCreatePanel();", true);
        }

        protected void SortInitially_ServerClick(object sender, EventArgs e)
        {
            this.OrganizationsListView.DataSource = this.Model.Organizations.OrderBy(x => x.Id).ToList();
            this.OrganizationsListView.DataBind();
        }

        protected void SortByName_ServerClick(object sender, EventArgs e)
        {
            this.OrganizationsListView.DataSource = this.Model.Organizations.OrderBy(x => x.Name).ToList();
            this.OrganizationsListView.DataBind();
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

            this.OrganizationsListView.DataSource = this.Model.Organizations;
            this.OrganizationsListView.DataBind();
        }

        protected void OrganizationsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            string currentUser = this.Page.User.Identity.GetUserName();
            var organization = (OrganizationDTO)e.Item.DataItem;
            var joinBtn = (Button)e.Item.Controls[1];

            this.CanJoinOrganization?.Invoke(sender, new OrganizationsEventArgs(organization.Id, currentUser));

            if (this.Model.CanJoinOrganization)
            {
                joinBtn.Visible = false;
            }
        }

        protected void JoinOrganizationBtn_Click(object sender, EventArgs e)
        {
            var joinBtn = sender as Button;

            try
            {
                string currentUser = this.Page.User.Identity.GetUserName();
                int organizationId = int.Parse(joinBtn.CommandArgument);
                this.JoinOrganization?.Invoke(sender, new OrganizationsEventArgs(organizationId, currentUser));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "joinSuccess();", true);
                this.OrganizationsListView.DataSource = this.Model.Organizations;
                this.OrganizationsListView.DataBind();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "joinFail();", true);
            }
        }
    }
}