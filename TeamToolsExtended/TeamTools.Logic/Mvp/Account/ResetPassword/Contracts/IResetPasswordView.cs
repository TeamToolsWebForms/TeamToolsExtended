using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.ResetPassword.Contracts
{
    public interface IResetPasswordView : IView<ResetPasswordViewModel>
    {
        event EventHandler<ResetPasswordEventArgs> GetUser;
    }
}
