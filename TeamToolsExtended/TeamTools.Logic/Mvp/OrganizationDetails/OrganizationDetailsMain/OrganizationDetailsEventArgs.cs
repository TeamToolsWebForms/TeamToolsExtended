using System;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain
{
    public class OrganizationDetailsEventArgs : EventArgs
    {
        public OrganizationDetailsEventArgs(string userId, int organizationId)
        {
            this.UserId = userId;
            this.OrganizationId = organizationId;
        }

        public OrganizationDetailsEventArgs(int organizationId, string username)
        {
            this.OrganizationId = organizationId;
            this.Username = username;
        }

        public string UserId { get; private set; }

        public int OrganizationId { get; private set; }

        public string Username { get; set; }
    }
}
