using System;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome
{
    public class OrganizationDetailsHomeEventArgs : EventArgs
    {
        public OrganizationDetailsHomeEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}
