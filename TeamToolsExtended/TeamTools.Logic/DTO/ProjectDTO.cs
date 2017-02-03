using System.Collections.Generic;

namespace TeamTools.Logic.DTO
{
    public class ProjectDTO
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string CreatorName { get; set; }

        public ICollection<UserDTO> Users;

        public ICollection<ProjectTaskDTO> ProjectTasks;

        public ICollection<MessageDTO> Messages;
    }
}
