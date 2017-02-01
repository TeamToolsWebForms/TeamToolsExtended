﻿using System.Collections.Generic;

namespace TeamTools.DataTransferObjects
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Gender { get; set; }
        
        public byte[] ProfileImage { get; set; }

        public ICollection<ProjectTaskDTO> ProjectTasks { get; set; }

        public ICollection<OrganizationDTO> Organizations;

        public ICollection<ProjectDTO> Projects;

        public ICollection<NoteDTO> Notes;
    }
}
