using System.Collections.Generic;

namespace TeamTools.Logic.DTO
{
    public class OrganizationDTO
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public OrganizationLogoDTO OrganizationLogo { get; set; }
        
        public string CreatorName { get; set; }

        public string OrganizationLogoUrl { get; set; }

        public ICollection<UserDTO> Users;

        public ICollection<ProjectDTO> Projects;
    }
}
