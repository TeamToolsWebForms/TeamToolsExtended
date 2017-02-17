using System.Collections.Generic;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IOrganizationService
    {
        void RemoveUserFromOrganization(string userId, int organizationId);

        ICollection<OrganizationDTO> GetUserOrganizations(string id);

        void Create(Organization organization, string userId);

        OrganizationDTO GetById(int id);
    }
}
