using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface IProfileHomeProjectsView : IView<ProfileHomeViewModel>
    {
        event EventHandler<ProfileHomeEventArgs> LoadUserWithPersonalProjects;
    }
}
