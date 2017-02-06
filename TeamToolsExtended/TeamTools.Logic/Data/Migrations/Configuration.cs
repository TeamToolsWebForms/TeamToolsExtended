using System.Data.Entity.Migrations;

namespace TeamTools.Logic.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TeamToolsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
