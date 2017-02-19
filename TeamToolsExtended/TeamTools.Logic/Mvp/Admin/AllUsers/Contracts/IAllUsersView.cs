using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Admin.AllUsers.Contracts
{
    public interface IAllUsersView : IView<AllUsersViewModel>
    {
        event EventHandler LoadUsers;
    }
}
