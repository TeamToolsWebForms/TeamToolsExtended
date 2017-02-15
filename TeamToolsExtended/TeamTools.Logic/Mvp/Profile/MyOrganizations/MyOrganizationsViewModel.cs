using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsViewModel
    {
        public ICollection<OrganizationDTO> MyOrganizations { get; set; }
    }
}
