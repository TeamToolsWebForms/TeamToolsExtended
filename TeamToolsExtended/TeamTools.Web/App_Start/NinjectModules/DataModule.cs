using Ninject.Modules;
using Ninject.Web.Common;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data;
using Ninject.Extensions.Factory;

namespace TeamTools.Web.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITeamToolsDbContext>().To<TeamToolsDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind<IStateFactory>().ToFactory().InSingletonScope();
            this.Bind(typeof(IEntryState<>)).To(typeof(EntryState<>));
        }
    }
}