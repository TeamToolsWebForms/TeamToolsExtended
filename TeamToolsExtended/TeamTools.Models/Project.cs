using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class Project
    {
        private ICollection<User> projectMembers;
        private ICollection<ProjectTask> tasks;
        private ICollection<Message> messages;

        public Project()
        {
            this.projectMembers = new HashSet<User>();
            this.tasks = new HashSet<ProjectTask>();
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<User> ProjectMembers
        {
            get { return this.projectMembers; }
            set { this.projectMembers = value; }
        }

        public virtual ICollection<ProjectTask> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
