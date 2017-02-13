using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IMyProjectDetailsView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> DeleteProject;
        event EventHandler<ProjectDetailsEventArgs> SaveDocument;
    }
}
