using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome.Contracts
{
    public interface IOrganizationDetailsHomeView : IView<OrganizationDetailsHomeViewModel>
    {
        event EventHandler<OrganizationDetailsHomeEventArgs> LoadOrganization;
    }
}
