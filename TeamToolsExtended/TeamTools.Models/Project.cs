using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class Project
    {
        private ICollection<User> users;
        private ICollection<ProjectTask> tasks;
        private ICollection<Message> messages;

        public Project()
        {
            this.users = new HashSet<User>();
            this.tasks = new HashSet<ProjectTask>();
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(150)]
        public string Title { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string CreatorName { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<ProjectTask> ProjectTasks
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
