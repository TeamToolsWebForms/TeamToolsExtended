using AjaxControlToolkit;
using System;
using System.Web.UI;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Ninject;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProjectDetailsPresenter))]
    public partial class ProjectDetails : MvpPage<ProjectDetailsViewModel>, IProjectDetailsView
    {
        [Inject]
        public IFileService FileService { get; set; }

        private const string RedirectUrl = "~/profile/myprojects.aspx";
        private int projectId;

        public event EventHandler<ProjectDetailsEventArgs> DeleteProject;
        
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
                    this.projectId = paramId;
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

        protected void ShowStatistics_ServerClick(object sender, EventArgs e)
        {
            this.ProjectDocumentsControl.Visible = false;
            this.ProjectStatsControl.Visible = true;
            this.ProjectDetailsContentControl.Visible = false;
        }

        protected void DeleteProjectBtn_Click(object sender, EventArgs e)
        {
            this.DeleteProject?.Invoke(sender, new ProjectDetailsEventArgs(this.projectId));
            this.Response.Redirect(RedirectUrl);
        }

        protected void closeDeleteProjectForm_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeDeleteProjectForm();", true);
        }

        protected void ShowTasks_ServerClick(object sender, EventArgs e)
        {
            this.ProjectDocumentsControl.Visible = false;
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = true;
        }

        protected void AjaxFileUpload_UploadComplete(object sender, AjaxFileUploadEventArgs e)
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
        
        protected void ShowDocuments_ServerClick(object sender, EventArgs e)
        {
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = false;
            this.ProjectDocumentsControl.Visible = true;
        }
    }
}