using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts
{
    public interface IMyOrganizationsView : IView<MyOrganizationsViewModel>
    {
        event EventHandler<OrganizationsEventArgs> LoadMyOrganizations;
        event EventHandler<OrganizationsEventArgs> SaveOrganization;
    }
}
