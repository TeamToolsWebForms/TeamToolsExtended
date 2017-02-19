using System;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsOrganization.Contracts
{
    public interface IProjectDetailsOrganizationView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> LoadProjectTasks;
        event EventHandler<ProjectDetailsEventArgs> UpdateProjectTask;
        event EventHandler<ProjectDetailsEventArgs> DeleteProjectTask;
        event EventHandler<ProjectDetailsEventArgs> CreateProjectTask;
        event EventHandler<ProjectDetailsEventArgs> LoadEditedTask;
        event EventHandler<ProjectDetailsEventArgs> AssignUserToTaskEv;
        event EventHandler<ProjectDetailsEventArgs> IsUserToAssignValid;
    }
}
