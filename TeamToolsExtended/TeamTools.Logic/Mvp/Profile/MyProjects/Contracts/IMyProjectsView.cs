using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjects.Contracts
{
    public interface IMyProjectsView : IView<MyProjectsViewModel>
    {
        event EventHandler<MyProjectsEventArgs> LoadUserProjects;
        event EventHandler<MyProjectsEventArgs> UpdateUserProject;
        event EventHandler<MyProjectsEventArgs> DeleteUserProject;
        event EventHandler<MyProjectsEventArgs> CreateUserProject;
    }
}
