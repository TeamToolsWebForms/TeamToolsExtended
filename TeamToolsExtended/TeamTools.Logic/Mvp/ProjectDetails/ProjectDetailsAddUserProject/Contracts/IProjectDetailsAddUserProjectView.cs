using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts
{
    public interface IProjectDetailsAddUserProjectView : IView<ProjectDetailsAddUserProjectViewModel>
    {
        event EventHandler<ProjectDetailsAddUserProjectEventArgs> CheckIsEmailValid;
        event EventHandler<ProjectDetailsAddUserProjectEventArgs> AddUserToProject;
        event EventHandler<ProjectDetailsAddUserProjectEventArgs> LoadOrganizationUsersUnsignedToProject;
    }
}
