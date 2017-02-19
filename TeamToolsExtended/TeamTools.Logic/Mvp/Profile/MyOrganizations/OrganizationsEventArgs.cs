using System;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class OrganizationsEventArgs : EventArgs
    {
        public OrganizationsEventArgs(string id)
        {
            this.Id = id;
        }

        public OrganizationsEventArgs(int organizationId, string username)
        {
            this.OrganizationId = organizationId;
            this.Username = username;
        }

        public OrganizationsEventArgs(string id, string name, string description, string username, string defaultLogoPath)
            : this(id)
        {
            this.Name = name;
            this.Description = description;
            this.Username = username;
            this.DefaultLogoPath = defaultLogoPath;
        }

        public string Id { get; set; }

        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public string DefaultLogoPath { get; set; }
    }
}
