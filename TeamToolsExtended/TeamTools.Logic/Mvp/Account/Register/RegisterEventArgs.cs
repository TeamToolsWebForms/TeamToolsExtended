using System;

namespace TeamTools.Logic.Mvp.Account.Register
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(string username, string email, string firstName, string lastName, string gender, string userLogoPath)
        {
            this.Username = username;
            this.Email = email;
            this.FistName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.UserLogoPath = userLogoPath;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string UserLogoPath { get; set; }
    }
}
