using System;
using System.Linq;
using System.Web.UI.WebControls;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProjectDocumentsPresenter))]
    public partial class ProjectDetailsDocuments : MvpUserControl<ProjectDetailsViewModel>, IMyProjectDocumentsView
    {
        private const string RedirectUrl = "~/Profile/MyProjects.aspx";

        public event EventHandler<ProjectDetailsEventArgs> GetDocuments;
        public event EventHandler<ProjectDetailsEventArgs> GetDocumentInfo;

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
                    this.GetDocuments?.Invoke(sender, new ProjectDetailsEventArgs(paramId));
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void DownloadBtn_Click(object sender, EventArgs e)
        {
            Button downloadBtn = (Button)sender;
            try
            {
                int documentId = int.Parse(downloadBtn.AccessKey);
                this.GetDocumentInfo?.Invoke(sender, new ProjectDetailsEventArgs(documentId));

                this.Response.ContentType = this.Model.DocumentInfo.FileExtension;
                this.Response.AddHeader("Content-Disposition", $"attachment;filename={this.Model.DocumentInfo.FileName}");
                this.Response.BinaryWrite(this.Model.DocumentInfo.FileContent);
                this.Response.End();
            }
            catch (FormatException)
            {
                // script error
            }
        }

        protected void MyProjectDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.MyProjectDocuments.PageIndex = e.NewPageIndex;
            this.MyProjectDocuments.DataBind();
        }

        public IQueryable<ProjectDocumentDTO> MyProjectDocuments_GetData()
        {
            return this.Model.Project.ProjectDocuments.OrderBy(x => x.Id).AsQueryable();
        }
    }
}