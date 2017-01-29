using Microsoft.AspNet.Identity.EntityFramework;
using TeamTools.Data.Contracts;
using TeamTools.Models;
using System.Data.Entity;

namespace TeamTools.Data
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

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
