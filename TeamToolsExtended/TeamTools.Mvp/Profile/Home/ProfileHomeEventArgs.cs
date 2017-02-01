using System;

namespace TeamTools.Mvp.Profile.Home
{
    public class ProfileHomeEventArgs : EventArgs
    {
        public ProfileHomeEventArgs(string id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }
}
