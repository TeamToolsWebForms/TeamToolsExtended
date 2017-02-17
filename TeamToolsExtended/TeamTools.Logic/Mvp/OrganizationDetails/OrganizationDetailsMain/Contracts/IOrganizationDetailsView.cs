using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts
{
    public interface IOrganizationDetailsView : IView<OrganizationDetailsViewModel>
    {
        event EventHandler<OrganizationDetailsEventArgs> LoadAllUsersWithoutCurrentMembers;
        event EventHandler<OrganizationDetailsEventArgs> LeaveOrganization;
    }
}
