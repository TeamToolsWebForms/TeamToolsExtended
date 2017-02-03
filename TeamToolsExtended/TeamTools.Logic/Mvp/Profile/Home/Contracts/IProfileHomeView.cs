using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface IProfileHomeView : IView<ProfileHomeViewModel>
    {
        event EventHandler<ProfileHomeEventArgs> LoadUserData;
    }
}
