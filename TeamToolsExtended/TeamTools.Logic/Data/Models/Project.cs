using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Logic.Data.Models
{
    public class Project
    {
        private ICollection<User> users;
        private ICollection<ProjectTask> tasks;
        private ICollection<Message> messages;
        private ICollection<ProjectDocument> projectDocuments;

        public Project()
        {
            this.users = new HashSet<User>();
            this.tasks = new HashSet<ProjectTask>();
            this.messages = new HashSet<Message>();
            this.projectDocuments = new HashSet<ProjectDocument>();
        }

        public Project(string title, string description, string username)
            : this()
        {
            this.Title = title;
            this.Description = description;
            this.CreatorName = username;
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string CreatorName { get; set; }

        public int OrganizationId { get; set; }

        public bool IsPersonal { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProjectDocument> ProjectDocuments
        {
            get { return this.projectDocuments; }
            set { this.projectDocuments = value; }
        }

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
