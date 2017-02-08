using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using TeamTools.Logic.Mvp.Profile.Home;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjects;
using TeamTools.Web.Helpers;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(MyProjectsPresenter))]
    public partial class MyProjects : MvpUserControl<MyProjectsViewModel>, IMyProjectsView
    {
        private const int MinTitleLength = 3;
        private const int MaxTitleLength = 100;

        public event EventHandler<MyProjectsEventArgs> LoadUserProjects;
        public event EventHandler<MyProjectsEventArgs> UpdateUserProject;
        public event EventHandler<MyProjectsEventArgs> DeleteUserProject;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();
            this.LoadUserProjects?.Invoke(this, new MyProjectsEventArgs(userId, username));
        }

        protected void MyProjectsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.MyProjectsGrid.PageIndex = e.NewPageIndex;
            this.MyProjectsGrid.DataSource = this.Model.User.Projects;
            this.MyProjectsGrid.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ProjectDTO> MyProjectsGrid_GetData()
        {
            return this.Model.User.Projects.OrderBy(x => x.Id).AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MyProjectsGrid_UpdateItem(int id)
        {
            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();
            var editTitleBox = this.MyProjectsGrid.Rows[this.MyProjectsGrid.EditIndex].Controls[1].Controls[0] as TextBox;
            if (!Validator.ValidateRange(editTitleBox.Text, MinTitleLength, MaxTitleLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
                return;
            }

            this.UpdateUserProject?.Invoke(this, new MyProjectsEventArgs(userId, username, id, editTitleBox.Text));

            this.MyProjectsGrid.DataBind();
        }
    }
}