using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTools.Models
{
    public class Organization
    {
        // organization logo and then test

        private ICollection<User> members;
        private ICollection<Project> projects;

        public Organization()
        {
            this.members = new HashSet<User>();
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

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }
    }
}
