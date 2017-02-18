using System;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject
{
    public class ProjectDetailsAddUserProjectEventArgs : EventArgs
    {
        public ProjectDetailsAddUserProjectEventArgs(int organizationId, string email)
        {
            this.OrganizationId = organizationId;
            this.Email = email;
        }

        public ProjectDetailsAddUserProjectEventArgs(int projectId, int organizationId)
        {
            this.ProjectId = projectId;
            this.OrganizationId = organizationId;
        }

        public ProjectDetailsAddUserProjectEventArgs(int projectId, int organizationId, string email)
            : this(organizationId, email)
        {
            this.ProjectId = projectId;
        }

        public int ProjectId { get; private set; }

        public int OrganizationId { get; private set; }

        public string Email { get; private set; }
    }
}
