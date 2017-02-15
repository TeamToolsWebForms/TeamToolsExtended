using System;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsEventArgs : EventArgs
    {
        public MyOrganizationsEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
