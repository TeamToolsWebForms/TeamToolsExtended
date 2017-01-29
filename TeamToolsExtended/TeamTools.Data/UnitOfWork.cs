using TeamTools.Data.Contracts;

namespace TeamTools.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITeamToolsDbContext dbContext;

        public UnitOfWork(ITeamToolsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
