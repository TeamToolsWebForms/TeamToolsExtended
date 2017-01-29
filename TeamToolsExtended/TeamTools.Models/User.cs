using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class User : IdentityUser
    {
        private ICollection<Organization> organizations;
        private ICollection<Project> personalProjects;
        private ICollection<Note> notes;

        public User()
            : base()
        {
            this.organizations = new HashSet<Organization>();
            this.personalProjects = new HashSet<Project>();
            this.notes = new HashSet<Note>();
        }

        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        public string Gender { get; set; }

        // profile image
        // friends may be

        public virtual ICollection<Organization> Organizations
        {
            get { return this.organizations; }
            set { this.organizations = value; }
        }

        public virtual ICollection<Project> PersonalProjects
        {
            get { return this.personalProjects; }
            set { this.personalProjects = value; }
        }

        public virtual ICollection<Note> Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
