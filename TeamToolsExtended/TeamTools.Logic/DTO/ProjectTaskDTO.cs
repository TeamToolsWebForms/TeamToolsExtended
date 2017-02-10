using System.Collections.Generic;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.DTO
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string ExecutionTime { get; set; }

        public decimal ExecutionCost { get; set; }

        public TaskType Status { get; set; }

        public ProjectDTO Project { get; set; }
        
        public ICollection<UserDTO> Users;
    }
}
