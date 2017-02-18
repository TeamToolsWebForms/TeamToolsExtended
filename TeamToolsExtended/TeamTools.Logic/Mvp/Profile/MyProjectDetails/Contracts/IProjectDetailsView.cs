using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectDetailsView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> DeleteProject;
    }
}
