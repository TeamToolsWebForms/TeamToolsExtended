using System;

namespace TeamTools.Logic.Mvp.Admin.AllUsers
{
    public class AllUsersEventArgs : EventArgs
    {
        public AllUsersEventArgs(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; private set; }
    }
}
