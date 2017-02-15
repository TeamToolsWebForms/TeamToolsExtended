using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts
{
    public interface IMyOrganizationsView : IView<MyOrganizationsViewModel>
    {
        event EventHandler<MyOrganizationsEventArgs> LoadMyOrganizations;
        event EventHandler<MyOrganizationsEventArgs> SaveOrganization;
    }
}
