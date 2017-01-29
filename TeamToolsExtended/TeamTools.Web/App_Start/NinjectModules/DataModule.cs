using Ninject.Modules;
using Ninject.Web.Common;
using TeamTools.Data.Contracts;
using TeamTools.Data;

namespace TeamTools.Web.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITeamToolsDbContext>().To<TeamToolsDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InSingletonScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}