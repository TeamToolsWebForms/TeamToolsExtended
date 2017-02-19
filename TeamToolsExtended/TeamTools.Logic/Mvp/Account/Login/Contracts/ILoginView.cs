using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.Login.Contracts
{
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler<LoginEventArgs> CheckIsBanned;
    }
}
