using System.Collections.Generic;

namespace TeamTools.Logic.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string CreatorName { get; set; }

        public ICollection<ProjectDocumentDTO> ProjectDocuments { get; set; }

        public ICollection<UserDTO> Users;

        public ICollection<ProjectTaskDTO> ProjectTasks;

        public ICollection<MessageDTO> Messages;

        public bool IsDeleted { get; set; }
    }
}
