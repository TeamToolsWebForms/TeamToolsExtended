using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTools.Logic.Data.Models
{
    public class Organization
    {
        private ICollection<User> users;
        private ICollection<Project> projects;

        public Organization()
        {
            this.users = new HashSet<User>();
            this.projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(4)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual OrganizationLogo OrganizationLogo { get; set; }

        [MaxLength(150)]
        public string CreatorName { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }
    }
}
