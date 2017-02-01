using System.Collections.Generic;
using TeamTools.Models.Enums;

namespace TeamTools.DataTransferObjects
{
    public class ProjectTaskDTO
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string ExecutionTime { get; set; }

        public decimal ExecutionCost { get; set; }

        public TaskType Status { get; set; }

        public ProjectDTO Project { get; set; }

        public ICollection<UserDTO> Users;
    }
}
