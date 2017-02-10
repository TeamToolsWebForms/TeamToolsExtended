using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.DTO;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks.Contracts;
using WebFormsMvp;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProjectTasksPresenter))]
    public partial class ProjectDetailsTasks : MvpUserControl<ProjectTasksViewModel>, IProjectTasksView
    {
        private const int MinTitleLength = 3;
        private const int MaxTitleLength = 100;
        private const int MaxDescriptionLength = 200;
        
        public event EventHandler<ProjectTasksEventArgs> LoadProjectTasks;
        public event EventHandler<ProjectTasksEventArgs> UpdateProjectTask;
        public event EventHandler<ProjectTasksEventArgs> DeleteProjectTask;
        public event EventHandler<ProjectTasksEventArgs> CreateProjectTask;

        protected void Page_Load(object sender, EventArgs e)
        {
            int paramId = int.Parse(Request.Params["id"]);
            this.LoadProjectTasks?.Invoke(this, new ProjectTasksEventArgs(paramId));
        }

        protected void MyProjectTasksGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.MyProjectTasksGrid.PageIndex = e.NewPageIndex;
            this.MyProjectTasksGrid.DataBind();
        }

        public IQueryable<ProjectTaskDTO> MyProjectTasksGrid_GetData()
        {
            return this.Model.Project.ProjectTasks.OrderByDescending(x => x.Id).AsQueryable();
        }

        public void MyProjectTasksGrid_UpdateItem(int id)
        {
            //string userId = Page.User.Identity.GetUserId();
            //string username = Page.User.Identity.GetUserName();
            //var editTitleBox = this.MyProjectsGrid.Rows[this.MyProjectsGrid.EditIndex].Controls[2].Controls[0] as TextBox;
            //if (!Validator.ValidateRange(editTitleBox.Text, MinTitleLength, MaxTitleLength))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
            //    return;
            //}

            //this.UpdateUserProject?.Invoke(this, new MyProjectsEventArgs(userId, username, id, editTitleBox.Text));

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "updateProjectSuccess();", true);
            this.MyProjectTasksGrid.DataBind();
        }

        public void MyProjectTasksGrid_DeleteItem(int id)
        {
            //string userId = Page.User.Identity.GetUserId();
            //string username = Page.User.Identity.GetUserName();

            //this.DeleteUserProject?.Invoke(this, new MyProjectsEventArgs(userId, username, id));

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "deleteProjectSuccess();", true);
            this.MyProjectTasksGrid.DataBind();
        }

        protected void SaveTask_Click(object sender, EventArgs e)
        {

        }
    }
}