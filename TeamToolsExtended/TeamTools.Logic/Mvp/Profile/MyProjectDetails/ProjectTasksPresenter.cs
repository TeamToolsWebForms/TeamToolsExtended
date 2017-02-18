using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectTasksPresenter : Presenter<IProjectTasksView>
    {
        private readonly IProjectTaskService projectTaskService;
        private readonly IProjectService projectService;
        private readonly IProjectTaskFactory projectTaskFactory;

        public ProjectTasksPresenter(IProjectTasksView view, IProjectService projectService, IProjectTaskService projectTaskService, IProjectTaskFactory projectTaskFactory)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();
            Guard.WhenArgument(projectTaskService, "ProjectTask Service").IsNull().Throw();
            Guard.WhenArgument(projectTaskFactory, "ProjectTask Factory").IsNull().Throw();

            this.View.LoadProjectTasks += this.View_LoadProjectTasks;
            this.View.UpdateProjectTask += this.View_UpdateProjectTask;
            this.View.DeleteProjectTask += this.View_DeleteProjectTask;
            this.View.CreateProjectTask += this.View_CreateProjectTask;
            this.View.LoadEditedTask += this.View_LoadEditedTask;
            this.View.AssignUserToTaskEv += this.View_AssignUserToTaskEv;
            this.View.IsUserToAssignValid += this.View_IsUserToAssignValid;

            this.projectService = projectService;
            this.projectTaskService = projectTaskService;
            this.projectTaskFactory = projectTaskFactory;
        }

        private void View_IsUserToAssignValid(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.IsUserInValid = this.projectTaskService.IsUserToAssignValid(e.Id, e.Username);
        }

        private void View_AssignUserToTaskEv(object sender, ProjectDetailsEventArgs e)
        {
            this.projectTaskService.AssignUserToTask(e.Id, e.Username);
        }

        private void View_LoadEditedTask(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.EditableTask = this.projectTaskService.GetById(e.Id);
            this.View.Model.UserSignedToProjectJson = this.projectTaskService.GetUsersNotSignedToTask(e.Id, e.OrganizationId);
        }

        private void View_CreateProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            var projectTask = this.projectTaskFactory.CreateProjectTask(e.TaskTitle, e.TaskDescription, e.DueDate, e.TaskExecutionCost, e.TaskStatus, e.Id);
            this.projectTaskService.Create(projectTask);
        }

        private void View_DeleteProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            this.projectTaskService.Delete(e.Id);
        }

        private void View_UpdateProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            this.projectTaskService.Update(e.Id, e.TaskTitle, e.TaskDescription, e.DueDate, e.TaskExecutionCost, e.TaskStatus);
        }

        private void View_LoadProjectTasks(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetById(e.Id);
        }
    }
}
