using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts
{
    public interface IOrganizationLogoFactory
    {
        OrganizationLogo CreateOrganizationLogo(byte[] image);
    }
}
