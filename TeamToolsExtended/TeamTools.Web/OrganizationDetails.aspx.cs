using System;
using System.Web.UI;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using Ninject;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(OrganizationDetailsPresenter))]
    public partial class OrganizationDetails : MvpPage<OrganizationDetailsViewModel>, IOrganizationDetailsView
    {
        private const string RedirectUrl = "~/profile/myorganizations";
        private int organizationId;

        [Inject]
        public IFileService FileService { get; set; }
        public event EventHandler<OrganizationDetailsEventArgs> LoadAllUsersWithoutCurrentMembers;
        public event EventHandler<OrganizationDetailsEventArgs> LeaveOrganization;

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
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void OrganizationProfile_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = false;
            this.OrganizationAddUserControl.Visible = false;
            this.OrganizationHomeControl.Visible = true;
        }

        protected void LeaveOrganizationBtn_ServerClick(object sender, EventArgs e)
        {
            string userId = this.Page.User.Identity.GetUserId();
            this.LeaveOrganization?.Invoke(sender, new OrganizationDetailsEventArgs(userId, this.organizationId));
            this.Response.Redirect(RedirectUrl);
        }

        protected void OrganizationAddUser_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = false;
            this.OrganizationAddUserControl.Visible = true;
            this.OrganizationHomeControl.Visible = false;

            string userId = this.Page.User.Identity.GetUserId();
            this.LoadAllUsersWithoutCurrentMembers?.Invoke(sender, new OrganizationDetailsEventArgs(userId, this.organizationId));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "loadUsers(" + this.Model.UsersWithoutCurrentMembersJson + ")", true);
        }

        protected void OrganizationProjects_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = true;
            this.OrganizationAddUserControl.Visible = false;
            this.OrganizationHomeControl.Visible = false;
        }

        protected void ChangeLogo_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showFileUpload();", true);
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
                    this.FileService.UpdateDocument(content, paramId);
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }
    }
}