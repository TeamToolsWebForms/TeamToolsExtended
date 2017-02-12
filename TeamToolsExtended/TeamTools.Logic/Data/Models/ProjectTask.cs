using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Data.Models
{
    public class ProjectTask
    {
        private ICollection<User> users;

        public ProjectTask()
        {
            this.users = new HashSet<User>();
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
        
        public DateTime? DueDate { get; set; }

        public decimal ExecutionCost { get; set; }

        public TaskType Status { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public bool IsDeleted { get; set; }
    }
}
