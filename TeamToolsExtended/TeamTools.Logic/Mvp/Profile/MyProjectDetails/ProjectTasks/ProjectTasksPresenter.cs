using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks
{
    public class ProjectTasksPresenter : Presenter<IProjectTasksView>
    {
        // private readonly IProjectTaskService projectTaskService;
        private readonly IProjectService projectService;

        public ProjectTasksPresenter(IProjectTasksView view, IProjectService projectService)
            : base(view)
        {
            this.View.LoadProjectTasks += View_LoadProjectTasks;
            this.View.UpdateProjectTask += View_UpdateProjectTask;
            this.View.DeleteProjectTask += View_DeleteProjectTask;
            this.View.CreateProjectTask += View_CreateProjectTask;

            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();
            this.projectService = projectService;
        }

        private void View_CreateProjectTask(object sender, ProjectTasksEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_DeleteProjectTask(object sender, ProjectTasksEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_UpdateProjectTask(object sender, ProjectTasksEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_LoadProjectTasks(object sender, ProjectTasksEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetById(e.ProjectId);
        }
    }
}
