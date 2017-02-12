using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.DTO;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProjectTasksPresenter))]
    public partial class ProjectDetailsTasks : MvpUserControl<ProjectDetailsViewModel>, IProjectTasksView
    {
        private const string RedirectUrl = "~/Profile/MyProjects.aspx";
        private const int MinTitleLength = 3;
        private const int MaxTitleLength = 100;
        private const int MaxDescriptionLength = 200;
        private int projectId;

        public event EventHandler<ProjectDetailsEventArgs> LoadProjectTasks;
        public event EventHandler<ProjectDetailsEventArgs> UpdateProjectTask;
        public event EventHandler<ProjectDetailsEventArgs> DeleteProjectTask;
        public event EventHandler<ProjectDetailsEventArgs> CreateProjectTask;

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
                    this.LoadProjectTasks?.Invoke(this, new ProjectDetailsEventArgs(paramId));
                }
                catch (FormatException)
                {
                    Response.Redirect(RedirectUrl);
                }
            }
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

        protected void CreateTask_ServerClick(object sender, EventArgs e)
        {
            string taskTitle = this.TaskName.Text;
            string taskDescription = this.taskDescription.InnerText;
            decimal executionCost;
            DateTime? dueDate;
            TaskType taskStatus;
            try
            {
                dueDate = DateTime.Parse(this.TaskEndDate.Text);
                executionCost = decimal.Parse(this.taskCost.Value);
                taskStatus = (TaskType)Enum.Parse(typeof(TaskType), this.TaskStatus.SelectedItem.Text);

                this.CreateProjectTask?.Invoke(sender, new ProjectDetailsEventArgs(taskTitle, taskDescription, dueDate, executionCost, taskStatus, this.projectId));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "createNewTask();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "parseError();", true);
            }
        }

        protected void EditTaskBtn_Click(object sender, EventArgs e)
        {

        }

        protected void CreateNew_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showNewTaskPanel();", true);
        }

        protected void closeTaskForm_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeNewTaskPanel();", true);
        }
    }
}