using System.Data.Entity;
using TeamTools.Data;
using TeamTools.Data.Migrations;

namespace TeamTools.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeamToolsDbContext, Configuration>());
            TeamToolsDbContext.Create().Database.Initialize(true);
        }
    }
}