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

        public string UserId { get; private set; }

        public int OrganizationId { get; private set; }
    }
}
