using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Organizations
{
    public class OrganizationsViewModel
    {
        public ICollection<OrganizationDTO> Organizations { get; set; }

        public bool CanJoinOrganization { get; set; }
    }
}
