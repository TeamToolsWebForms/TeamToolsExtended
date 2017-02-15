using System;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsEventArgs : EventArgs
    {
        public MyOrganizationsEventArgs(string id)
        {
            this.Id = id;
        }

        public MyOrganizationsEventArgs(string id, string name, string description, string username, string defaultLogoPath)
            : this(id)
        {
            this.Name = name;
            this.Description = description;
            this.Username = username;
            this.DefaultLogoPath = defaultLogoPath;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public string DefaultLogoPath { get; set; }
    }
}
