using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.Register.Contracts
{
    public interface IRegisterView : IView<RegisterViewModel>
    {
        event EventHandler<RegisterEventArgs> GetUser;
    }
}
