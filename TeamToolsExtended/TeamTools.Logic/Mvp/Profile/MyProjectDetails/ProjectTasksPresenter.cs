using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Guard.WhenArgument(view, "View").IsNull().Throw();
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();
            Guard.WhenArgument(projectTaskService, "ProjectTask Service").IsNull().Throw();
            Guard.WhenArgument(projectTaskFactory, "ProjectTask Factory").IsNull().Throw();

            this.View.LoadProjectTasks += View_LoadProjectTasks;
            this.View.UpdateProjectTask += View_UpdateProjectTask;
            this.View.DeleteProjectTask += View_DeleteProjectTask;
            this.View.CreateProjectTask += View_CreateProjectTask;
            
            this.projectService = projectService;
            this.projectTaskService = projectTaskService;
            this.projectTaskFactory = projectTaskFactory;
        }

        private void View_CreateProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            var projectTask = this.projectTaskFactory.CreateProjectTask(e.TaskTitle, e.TaskDescription, e.DueDate, e.TaskExecutionCost, e.TaskStatus, e.ProjectId);
            this.projectTaskService.Create(projectTask);
        }

        private void View_DeleteProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_UpdateProjectTask(object sender, ProjectDetailsEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_LoadProjectTasks(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetById(e.ProjectId);
        }
    }
}
