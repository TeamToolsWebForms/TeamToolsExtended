using System;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects
{
    public class OrganizationDetailsProjectsEventArgs : EventArgs
    {
        public OrganizationDetailsProjectsEventArgs(int id)
        {
            this.Id = id;
        }

        public OrganizationDetailsProjectsEventArgs(int id, string projectTitle)
            : this(id)
        {
            this.ProjectTitle = projectTitle;
        }

        public OrganizationDetailsProjectsEventArgs(int id, string projectTitle, string description, string creatorName)
            : this(id, projectTitle)
        {
            this.Description = description;
            this.Creator = creatorName;
        }

        public int Id { get; private set; }

        public string ProjectTitle { get; private set; }

        public string Description { get; private set; }

        public string Creator { get; private set; }
    }
}
