using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Web.Helpers;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(OrganizationDetailsProjectsPresenter))]
    public partial class OrganizationDetailsProjects : MvpUserControl<OrganizationDetailsProjectsViewModel>, IOrganizationDetailsProjectsView
    {
        private const string RedirectUrl = "~/profile/myorganizations";
        private const int MinTitleLength = 3;
        private const int MaxTitleLength = 100;
        private const int MaxDescriptionLength = 200;
        private int organizationId;

        public event EventHandler<OrganizationDetailsProjectsEventArgs> LoadOrganization;
        public event EventHandler<OrganizationDetailsProjectsEventArgs> UpdateOrganizationProject;
        public event EventHandler<OrganizationDetailsProjectsEventArgs> DeleteOrganizationProject;
        public event EventHandler<OrganizationDetailsProjectsEventArgs> CreateProject;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Params["id"] == null)
            {
                this.Response.Redirect(RedirectUrl);
            }
            else
            {
                try
                {
                    int paramId = int.Parse(this.Request.Params["id"]);
                    this.organizationId = paramId;
                    this.LoadOrganization?.Invoke(sender, new OrganizationDetailsProjectsEventArgs(paramId));
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void CreateNew_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showCreatePanel();", true);
        }

        protected void ProjectsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ProjectsGrid.PageIndex = e.NewPageIndex;
            this.ProjectsGrid.DataBind();
        }

        public IQueryable<ProjectDTO> ProjectsGrid_GetData()
        {
            return this.Model.Organization.Projects.AsQueryable();
        }
        
        public void ProjectsGrid_UpdateItem(int id)
        {
            var editTitleBox = this.ProjectsGrid.Rows[this.ProjectsGrid.EditIndex].Controls[2].Controls[0] as TextBox;
            if (!Validator.ValidateRange(editTitleBox.Text, MinTitleLength, MaxTitleLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
                return;
            }

            this.UpdateOrganizationProject?.Invoke(this, new OrganizationDetailsProjectsEventArgs(id, editTitleBox.Text, this.organizationId));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "updateProjectSuccess();", true);
            this.ProjectsGrid.DataBind();
        }
        
        public void ProjectsGrid_DeleteItem(int id)
        {
            this.DeleteOrganizationProject?.Invoke(this, new OrganizationDetailsProjectsEventArgs(id, "", this.organizationId));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "deleteProjectSuccess();", true);
            this.ProjectsGrid.DataBind();
        }

        protected void closeBtn_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeCreatePanel();", true);
        }

        protected void saveProject_Click(object sender, EventArgs e)
        {
            string projectName = this.ProjectName.Text;
            if (!Validator.ValidateRange(projectName, MinTitleLength, MaxTitleLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
                return;
            }

            string projectDescription = this.projectDesc.InnerText;
            if (!Validator.ValidateRange(projectDescription, MinTitleLength, MaxDescriptionLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "descriptionValidation();", true);
                return;
            }

            string creatorName = this.Page.User.Identity.GetUserName();
            this.CreateProject?.Invoke(this, new OrganizationDetailsProjectsEventArgs(this.organizationId, projectName, projectDescription, creatorName));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "createProjectSuccess();", true);

            this.ProjectsGrid.DataBind();
        }
    }
}