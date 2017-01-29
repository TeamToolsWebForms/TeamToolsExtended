using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamTools.Models.Enums;

namespace TeamTools.Models
{
    public class ProjectTask
    {
        private ICollection<User> relatedUsers;

        public ProjectTask()
        {
            this.relatedUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(15)]
        public string ExecutionTime { get; set; }

        public decimal ExecutionCost { get; set; }

        public TaskType Status { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<User> RelatedUsers
        {
            get { return this.relatedUsers; }
            set { this.relatedUsers = value; }
        }

        public bool IsDeleted { get; set; }
    }
}
