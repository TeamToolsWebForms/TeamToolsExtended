using System;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Organizations.Contracts
{
    public interface IOrganizationsView : IView<OrganizationsViewModel>
    {
        event EventHandler<OrganizationsEventArgs> LoadMyOrganizations;
        event EventHandler<OrganizationsEventArgs> SaveOrganization;
        event EventHandler<OrganizationsEventArgs> CanJoinOrganization;
        event EventHandler<OrganizationsEventArgs> JoinOrganization;
    }
}
