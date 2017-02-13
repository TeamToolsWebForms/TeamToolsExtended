using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IMyProjectDetailsChartView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> LoadProject;
    }
}
