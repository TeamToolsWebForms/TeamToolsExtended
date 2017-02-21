using Ninject;
using System;
using System.Web.UI;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(ProjectDetailsMainPresenter))]
    public partial class ProjectDetails : MvpPage<ProjectDetailsMainViewModel>, IProjectDetailsMainView
    {
        [Inject]
        public IFileService FileService { get; set; }

        private const string RedirectUrl = "~/organizations.aspx";
        private int projectId;
        private int organizationId;

        public event EventHandler<ProjectDetailsMainEventArgs> DeleteProject;
        public event EventHandler<ProjectDetailsMainEventArgs> LoadProjectMessages;

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
                    this.LoadProjectMessages?.Invoke(sender, new ProjectDetailsMainEventArgs(this.projectId));

                    this.MessageRepeater.DataSource = this.Model.Messages;
                    this.MessageRepeater.DataBind();
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void DeleteProjectBtn_Click(object sender, EventArgs e)
        {
            this.DeleteProject?.Invoke(sender, new ProjectDetailsMainEventArgs(this.projectId));
            this.Response.Redirect(RedirectUrl);
        }

        protected void closeDeleteProjectForm_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeDeleteProjectForm();", true);
        }

        protected void AjaxFileUpload_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
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
                    var content = e.GetContents();
                    this.FileService.SaveDocument(e.FileName, e.ContentType, content, paramId);
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void DeleteProjectButton_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showDeleteProjectPanel();", true);
        }

        protected void ShowDocuments_ServerClick(object sender, EventArgs e)
        {
            this.AddUserToProjectControl.Visible = false;
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = false;
            this.ProjectDocumentsControl.Visible = true;
        }

        protected void ShowStatistics_ServerClick(object sender, EventArgs e)
        {
            this.AddUserToProjectControl.Visible = false;
            this.ProjectDocumentsControl.Visible = false;
            this.ProjectStatsControl.Visible = true;
            this.ProjectDetailsContentControl.Visible = false;
        }

        protected void ShowTasks_ServerClick(object sender, EventArgs e)
        {
            this.AddUserToProjectControl.Visible = false;
            this.ProjectDocumentsControl.Visible = false;
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = true;
        }

        protected void AddUserToProject_ServerClick(object sender, EventArgs e)
        {
            this.ProjectDocumentsControl.Visible = false;
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = false;
            this.AddUserToProjectControl.Visible = true;
        }
    }
}