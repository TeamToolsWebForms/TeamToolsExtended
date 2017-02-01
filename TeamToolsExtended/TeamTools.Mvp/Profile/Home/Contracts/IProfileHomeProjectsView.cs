using System;
using WebFormsMvp;

namespace TeamTools.Mvp.Profile.Home.Contracts
{
    public interface IProfileHomeProjectsView : IView<ProfileHomeViewModel>
    {
        event EventHandler<ProfileHomeEventArgs> LoadUserWithPersonalProjects;
    }
}
