using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using TeamTools.Logic.Mvp.Profile.Home;
using WebFormsMvp.Web;
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
            this.MyProjectsGrid.DataBind();
        }
        
        public IQueryable<ProjectDTO> MyProjectsGrid_GetData()
        {
            return this.Model.User.Projects.OrderBy(x => x.Id).AsQueryable();
        }
        
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "updateProjectSuccess();", true);
            this.MyProjectsGrid.DataBind();
        }
        
        public void MyProjectsGrid_DeleteItem(int id)
        {
            string userId = Page.User.Identity.GetUserId();
            string username = Page.User.Identity.GetUserName();

            this.DeleteUserProject?.Invoke(this, new MyProjectsEventArgs(userId, username, id));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "deleteProjectSuccess();", true);
            this.MyProjectsGrid.DataBind();
        }
    }
}