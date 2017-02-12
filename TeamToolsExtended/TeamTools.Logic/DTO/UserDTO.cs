using System.Collections.Generic;

namespace TeamTools.Logic.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Gender { get; set; }
        
        public UserLogoDTO UserLogo { get; set; }

        public ICollection<OrganizationDTO> Organizations;

        public ICollection<ProjectDTO> Projects;

        public ICollection<NoteDTO> Notes;
    }
}
