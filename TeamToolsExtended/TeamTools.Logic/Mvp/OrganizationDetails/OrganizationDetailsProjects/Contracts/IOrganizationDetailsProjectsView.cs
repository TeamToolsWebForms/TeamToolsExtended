using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts
{
    public interface IOrganizationDetailsProjectsView : IView<OrganizationDetailsProjectsViewModel>
    {
        event EventHandler<OrganizationDetailsProjectsEventArgs> LoadOrganization;
        event EventHandler<OrganizationDetailsProjectsEventArgs> UpdateOrganizationProject;
        event EventHandler<OrganizationDetailsProjectsEventArgs> DeleteOrganizationProject;
        event EventHandler<OrganizationDetailsProjectsEventArgs> CreateProject;
    }
}
