using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts
{
    public interface IOrganizationFactory
    {
        Organization CreateOrganization(string name, string description, OrganizationLogo organizationLogo, string creatorName, string organizationLogoUrl);
    }
}
