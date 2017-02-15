using System;

namespace TeamTools.Logic.Mvp.Account.ResetPassword
{
    public class ResetPasswordEventArgs : EventArgs
    {
        public ResetPasswordEventArgs(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}
