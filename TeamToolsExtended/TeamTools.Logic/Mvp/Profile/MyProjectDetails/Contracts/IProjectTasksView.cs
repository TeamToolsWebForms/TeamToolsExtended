using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectTasksView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> LoadProjectTasks;
        event EventHandler<ProjectDetailsEventArgs> UpdateProjectTask;
        event EventHandler<ProjectDetailsEventArgs> DeleteProjectTask;
        event EventHandler<ProjectDetailsEventArgs> CreateProjectTask;
        event EventHandler<ProjectDetailsEventArgs> LoadEditedTask;
    }
}
