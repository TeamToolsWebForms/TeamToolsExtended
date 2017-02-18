using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectDetailsChartView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> LoadProject;
    }
}
