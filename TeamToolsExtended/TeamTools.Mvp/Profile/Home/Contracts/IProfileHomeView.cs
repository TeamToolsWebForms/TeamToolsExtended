using System;
using WebFormsMvp;

namespace TeamTools.Mvp.Profile.Home.Contracts
{
    public interface IProfileHomeView : IView<ProfileHomeViewModel>
    {
        event EventHandler<ProfileHomeEventArgs> LoadUserData;
    }
}
