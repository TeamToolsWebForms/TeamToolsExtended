using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;

namespace TeamTools.Logic.Data
{
    public class TeamToolsDbContext : IdentityDbContext<User>, ITeamToolsDbContext
    {
        public TeamToolsDbContext()
            : base("TeamToolsDB")
        {
        }

        public static TeamToolsDbContext Create()
        {
            return new TeamToolsDbContext();
        }

        public virtual IDbSet<Organization> Organizations { get; set; }
               
        public virtual IDbSet<ProjectTask> ProjectTasks { get; set; }
               
        public virtual IDbSet<Message> Messages { get; set; }
               
        public virtual IDbSet<Note> Notes { get; set; }
               
        public virtual IDbSet<Project> Projects { get; set; }
               
        public virtual IDbSet<OrganizationLogo> OrganizationLogos { get; set; }
               
        public virtual IDbSet<UserLogo> UserLogos { get; set; }

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
