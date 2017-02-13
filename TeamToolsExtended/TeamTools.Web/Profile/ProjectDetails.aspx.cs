using AjaxControlToolkit;
using System;
using System.Web.UI;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(MyProjectDetailsPresenter))]
    public partial class ProjectDetails : MvpPage<ProjectDetailsViewModel>, IMyProjectDetailsView
    {
        private const string RedirectUrl = "~/Profile/MyProjects.aspx";
        private int projectId;

        public event EventHandler<ProjectDetailsEventArgs> DeleteProject;
        public event EventHandler<ProjectDetailsEventArgs> SaveDocument;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect(RedirectUrl);
            }
            else
            {
                try
                {
                    int paramId = int.Parse(Request.Params["id"]);
                    this.projectId = paramId;
                }
                catch (FormatException)
                {
                    Response.Redirect(RedirectUrl);
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
            var content = e.GetContents();
            var str = string.Empty;
            foreach (var bit in content)
            {
                str += bit;
            }

            this.SaveDocument?.Invoke(sender, new ProjectDetailsEventArgs(this.projectId, e.FileName, e.ContentType, e.GetContents()));
        }

        protected void ShowDocuments_ServerClick(object sender, EventArgs e)
        {
            this.ProjectStatsControl.Visible = false;
            this.ProjectDetailsContentControl.Visible = false;
            this.ProjectDocumentsControl.Visible = true;
        }
    }
}