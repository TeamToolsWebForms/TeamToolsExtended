using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.DTO;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using TeamTools.Logic.Data.Models.Enums;
using TeamTools.Web.Helpers;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProjectTasksPresenter))]
    public partial class ProjectDetailsTasks : MvpUserControl<ProjectDetailsViewModel>, IProjectTasksView
    {
        private const string RedirectUrl = "~/profile/myprojects.aspx";
        private const int MinLength = 3;
        private const int MaxTitleLength = 100;
        private const int MaxDescriptionLength = 200;
        private int projectId;

        public event EventHandler<ProjectDetailsEventArgs> LoadProjectTasks;
        public event EventHandler<ProjectDetailsEventArgs> UpdateProjectTask;
        public event EventHandler<ProjectDetailsEventArgs> DeleteProjectTask;
        public event EventHandler<ProjectDetailsEventArgs> CreateProjectTask;
        public event EventHandler<ProjectDetailsEventArgs> LoadEditedTask;

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
                    int paramId = int.Parse(Request.Params["id"]);
                    this.projectId = paramId;
                    this.LoadProjectTasks?.Invoke(this, new ProjectDetailsEventArgs(paramId));
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
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

        public void MyProjectTasksGrid_DeleteItem(int id)
        {
            this.DeleteProjectTask?.Invoke(this, new ProjectDetailsEventArgs(id));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "deleteProjectTaskSuccess();", true);
            this.MyProjectTasksGrid.DataBind();
        }

        protected void CreateTask_ServerClick(object sender, EventArgs e)
        {
            string taskTitle = this.TaskName.Text;
            if (!Validator.ValidateRange(taskTitle, MinLength, MaxTitleLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "taskTitleValidation();", true);
                return;
            }

            string taskDescription = this.taskDescription.InnerText;
            if (!Validator.ValidateRange(taskDescription, MinLength, MaxDescriptionLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "taskDescriptionValidation();", true);
                return;
            }

            decimal executionCost;
            DateTime? dueDate;
            TaskType taskStatus;
            try
            {
                if (this.TaskEndDate.Text != string.Empty)
                {
                    dueDate = DateTime.Parse(this.TaskEndDate.Text);
                }
                else
                {
                    dueDate = null;
                }
                
                if (this.taskCost.Value == string.Empty)
                {
                    executionCost = 0;
                }
                else
                {
                    executionCost = decimal.Parse(this.taskCost.Value);
                }
                
                taskStatus = (TaskType)Enum.Parse(typeof(TaskType), this.TaskStatus.SelectedItem.Text);

                this.CreateProjectTask?.Invoke(sender, new ProjectDetailsEventArgs(taskTitle, taskDescription, dueDate, executionCost, taskStatus, this.projectId));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "createNewTask();", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "parseError();", true);
            }
        }

        protected void CreateNew_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showNewTaskPanel();", true);
        }

        protected void closeTaskForm_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeNewTaskPanel();", true);
        }

        protected void closeEditTaskPanel_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "closeEditTaskPanel();", true);
        }

        protected void EditTaskButton_ServerClick(object sender, EventArgs e)
        {
            string taskTitle = this.EditTaskTitle.Text;
            if (!Validator.ValidateRange(taskTitle, MinLength, MaxTitleLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "taskTitleValidation();", true);
                return;
            }

            string taskDescription = this.EditTaskDescription.InnerText;
            if (!Validator.ValidateRange(taskDescription, MinLength, MaxDescriptionLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "taskDescriptionValidation();", true);
                return;
            }

            decimal executionCost;
            DateTime? dueDate;
            TaskType taskStatus;
            try
            {
                if (this.EditTaskEndDate.Text != string.Empty)
                {
                    dueDate = DateTime.Parse(this.EditTaskEndDate.Text);
                }
                else
                {
                    dueDate = null;
                }

                if (this.EditTaskCost.Value == string.Empty)
                {
                    executionCost = 0;
                }
                else
                {
                    executionCost = decimal.Parse(this.EditTaskCost.Value);
                }

                taskStatus = (TaskType)Enum.Parse(typeof(TaskType), this.EditTaskStatus.SelectedItem.Text);

                int taskId = int.Parse(this.EditTaskId.Attributes["data-id"]);

                this.UpdateProjectTask?.Invoke(sender, new ProjectDetailsEventArgs(taskTitle, taskDescription, dueDate, executionCost, taskStatus, taskId));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "editTask();", true);
                this.MyProjectTasksGrid.DataBind();
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "parseError();", true);
            }
        }

        protected void EditTaskBtn_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            
            try
            {
                int taskId = int.Parse(btnEdit.CommandArgument);
                this.LoadEditedTask?.Invoke(sender, new ProjectDetailsEventArgs(taskId));

                this.EditTaskId.Attributes.Add("data-id", taskId.ToString());
                this.EditTaskTitle.Text = this.Model.EditableTask.Title;
                this.EditTaskDescription.InnerText = this.Model.EditableTask.Description;
                this.EditTaskEndDate.Text = this.Model.EditableTask.DueDate.ToString().Split(' ')[0];
                this.EditTaskCost.Value = this.Model.EditableTask.ExecutionCost.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showEditTaskPanel();", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "parseError();", true);
            }
        }
    }
}