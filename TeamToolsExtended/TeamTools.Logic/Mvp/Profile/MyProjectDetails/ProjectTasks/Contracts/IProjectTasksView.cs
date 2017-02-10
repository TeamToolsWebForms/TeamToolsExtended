using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks.Contracts
{
    public interface IProjectTasksView : IView<ProjectTasksViewModel>
    {
        event EventHandler<ProjectTasksEventArgs> LoadProjectTasks;
        event EventHandler<ProjectTasksEventArgs> UpdateProjectTask;
        event EventHandler<ProjectTasksEventArgs> DeleteProjectTask;
        event EventHandler<ProjectTasksEventArgs> CreateProjectTask;
    }
}
