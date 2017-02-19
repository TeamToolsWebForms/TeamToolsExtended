using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts
{
    public interface IProjectDetailsMainView : IView<ProjectDetailsMainViewModel>
    {
        event EventHandler<ProjectDetailsMainEventArgs> DeleteProject;
        event EventHandler<ProjectDetailsMainEventArgs> LoadProjectMessages;
    }
}
