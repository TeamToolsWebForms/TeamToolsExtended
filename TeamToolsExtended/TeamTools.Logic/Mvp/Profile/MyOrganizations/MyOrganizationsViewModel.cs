using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsViewModel
    {
        public IEnumerable<OrganizationDTO> MyOrganizations { get; set; }
    }
}
