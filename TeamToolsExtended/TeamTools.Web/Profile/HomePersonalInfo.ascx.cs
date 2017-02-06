using System;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using System.IO;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomePresenter))]
    public partial class HomePersonalInfo : MvpUserControl<ProfileHomeViewModel>, IProfileHomeView
    {
        private const int FiveMBs = 5 * 1024 * 1024;

        public event EventHandler<ProfileHomeEventArgs> LoadUserData;
        public event EventHandler<ProfileHomeEventArgs> SaveProfileImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FileUpload.Visible = false;
            this.UploadImage.Visible = false;

            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();
            this.LoadUserData?.Invoke(sender, new ProfileHomeEventArgs(userId, username));

            this.ProfileImage.ImageUrl = this.Model.ImageUrl;
        }

        protected void ShowUpload_Click(object sender, EventArgs e)
        {
            this.FileUpload.Visible = true;
            this.UploadImage.Visible = true;
            this.ShowUpload.Visible = false;
        }

        protected void ShowProjects_Click(object sender, EventArgs e)
        {
            this.ContentView.ActiveViewIndex = 1;
        }

        protected void ShowOrganizations_Click(object sender, EventArgs e)
        {
            this.ContentView.ActiveViewIndex = 0;
        }

        protected void UploadImage_Click(object sender, EventArgs e)
        {
            if (this.FileUpload.HasFile)
            {
                try
                {
                    if (this.FileUpload.PostedFile.ContentType == "image/jpeg")
                    {
                        if (this.FileUpload.PostedFile.ContentLength < FiveMBs)
                        {
                            string filename = Path.GetFileName(this.FileUpload.FileName);
                            string serverPath = Server.MapPath("~/Images/");
                            string userId = Page.User.Identity.GetUserId();
                            this.SaveProfileImage?.Invoke(sender, new ProfileHomeEventArgs(filename, this.FileUpload.PostedFile, serverPath, userId));

                            this.ProfileImage.ImageUrl = this.Model.ImageUrl;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "FileSuccess();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "FileMemory();", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "FileType();", true);
                    }

                    this.FileUpload.Visible = false;
                    this.UploadImage.Visible = false;
                    this.ShowUpload.Visible = true;
                }
                catch (Exception ex)
                {
                    // logging possibly
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "InternalError();", true);
                }
            }
        }
    }
}