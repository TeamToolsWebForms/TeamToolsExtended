﻿using System;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Mvp.Profile.Home.Contracts;
using TeamTools.Mvp.Profile.Home;
using WebFormsMvp;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(IProfileHomePresenter))]
    public partial class Home : MvpPage<ProfileHomeViewModel>, IProfileHomeView
    {
        public event EventHandler<ProfileHomeEventArgs> LoadUserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadUserData?.Invoke(sender, new ProfileHomeEventArgs() { Id = Page.User.Identity.GetUserId() });
            
            this.ProfileImage.ImageUrl = this.Model.ImageUrl;
        }

        protected void ImageUpload_Click(object sender, EventArgs e)
        {
            this.FileUpload.Visible = true;
            this.ImageUpload.Visible = false;
        }

        protected void ShowProjects_Click(object sender, EventArgs e)
        {
            this.ContentView.ActiveViewIndex = 1;
        }

        protected void ShowOrganizations_Click(object sender, EventArgs e)
        {
            this.ContentView.ActiveViewIndex = 0;
        }

        protected void ContentView_Load(object sender, EventArgs e)
        {
            this.ProfileOrganizations.DataSource = this.Model.User.Organizations;
            this.ProfileOrganizations.DataBind();
        }
    }
}