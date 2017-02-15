using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IOrganizationService
    {
        IEnumerable<OrganizationDTO> GetUserOrganizations(string id);
    }
}
