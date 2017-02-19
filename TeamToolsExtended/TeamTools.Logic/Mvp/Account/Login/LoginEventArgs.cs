using System;

namespace TeamTools.Logic.Mvp.Account.Login
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(string username)
        {
            this.Username = username;
        }

        public string Username { get; private set; }
    }
}
