using System;
using System.Web.UI;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(ProjectDetailsAddUserProjectPresenter))]
    public partial class ProjectDetailsAddUserToProject : MvpUserControl<ProjectDetailsAddUserProjectViewModel>, IProjectDetailsAddUserProjectView
    {
        private const string RedirectUrl = "~/organizations.aspx";
        private int projectId;
        private int organizationId;

        public event EventHandler<ProjectDetailsAddUserProjectEventArgs> CheckIsEmailValid;
        public event EventHandler<ProjectDetailsAddUserProjectEventArgs> AddUserToProject;
        public event EventHandler<ProjectDetailsAddUserProjectEventArgs> LoadOrganizationUsersUnsignedToProject;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Params["id"] == null || this.Request.Params["organization"] == null)
            {
                this.Response.Redirect(RedirectUrl);
            }
            else
            {
                try
                {
                    int queryProjectId = int.Parse(this.Request.Params["id"]);
                    int queryOrganizationId = int.Parse(this.Request.Params["organization"]);
                    this.projectId = queryProjectId;
                    this.organizationId = queryOrganizationId;
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }

            this.LoadOrganizationUsersUnsignedToProject?.Invoke(sender, new ProjectDetailsAddUserProjectEventArgs(this.projectId, this.organizationId));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "loadUsers(" + this.Model.UsersUnsignedToProjectJson + ");", true);
        }

        protected void AddUserToProjectBtn_Click(object sender, EventArgs e)
        {
            string email = this.ProjectUserField.Text;
            this.CheckIsEmailValid?.Invoke(sender, new ProjectDetailsAddUserProjectEventArgs(this.organizationId, email));

            if (this.Model.IsEmailValid)
            {
                this.AddUserToProject?.Invoke(sender, new ProjectDetailsAddUserProjectEventArgs(this.projectId, this.organizationId, email));
                
                this.ProjectUserField.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "successAddToProject();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "failAddToProject();", true);
            }
        }
    }
}