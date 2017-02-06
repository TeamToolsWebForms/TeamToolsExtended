using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface IProfileHomeOrganizationsView : IView<ProfileHomeViewModel>
    {
        event EventHandler<ProfileHomeEventArgs> LoadUserData;
    }
}
