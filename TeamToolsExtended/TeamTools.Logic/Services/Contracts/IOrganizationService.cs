using System.Collections.Generic;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IOrganizationService
    {
        void RemoveUserFromOrganization(string userId, int organizationId);

        ICollection<OrganizationDTO> GetOrganizations();

        ICollection<OrganizationDTO> GetUserOrganizations(string id);

        void Create(Organization organization, string userId);

        OrganizationDTO GetById(int id);

        bool CanUserJoinOrganization(int organizationId, string username);

        void JoinOrganization(int organizationId, string username);
    }
}
