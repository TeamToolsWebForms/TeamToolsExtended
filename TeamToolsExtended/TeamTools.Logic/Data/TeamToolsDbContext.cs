using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using Bytes2you.Validation;

namespace TeamTools.Logic.Data
{
    public class TeamToolsDbContext : IdentityDbContext<User>, ITeamToolsDbContext
    {
        private IStateFactory stateFactory;

        public TeamToolsDbContext()
            : base("TeamToolsDB")
        {
        }

        public TeamToolsDbContext(IStateFactory stateFactory)
            : base("TeamToolsDB")
        {
            Guard.WhenArgument(stateFactory, "StateFactory").IsNull().Throw();

            this.stateFactory = stateFactory;
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

        public IDbSet<ProjectDocument> ProjectDocuments { get; set; }

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IEntryState<T> GetState<T>(T entity) where T : class
        {
            return this.stateFactory.CreateState(this.Entry(entity));
        }
    }
}
