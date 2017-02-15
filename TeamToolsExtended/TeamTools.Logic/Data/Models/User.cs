using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TeamTools.Logic.Data.Models
{
    public class User: IdentityUser
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

        public User(string username, string email, string firstName, string lastName, string gender, UserLogo userLogo)
            : this()
        {
            this.UserName = username;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.UserLogo = userLogo;
        }

        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public int UserLogoId { get; set; }

        public virtual UserLogo UserLogo { get; set; }

        public virtual ICollection<Organization> Organizations
        {
            get { return this.organizations; }
            set { this.organizations = value; }
        }

        public virtual ICollection<Project> Projects
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
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
