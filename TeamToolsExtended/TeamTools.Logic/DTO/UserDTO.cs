using System.Collections.Generic;

namespace TeamTools.Logic.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Gender { get; set; }
        
        public UserLogoDTO ProfileImage { get; set; }

        public ICollection<ProjectTaskDTO> ProjectTasks { get; set; }

        public ICollection<OrganizationDTO> Organizations;

        public ICollection<ProjectDTO> Projects;

        public ICollection<NoteDTO> Notes;
    }
}
