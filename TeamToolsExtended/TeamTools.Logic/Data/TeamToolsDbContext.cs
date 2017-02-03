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

        public IDbSet<Organization> Organizations { get; set; }

        public IDbSet<ProjectTask> ProjectTasks { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Note> Notes { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<OrganizationLogo> OrganizationLogos { get; set; }

        public IDbSet<UserLogo> UserLogos { get; set; }

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
