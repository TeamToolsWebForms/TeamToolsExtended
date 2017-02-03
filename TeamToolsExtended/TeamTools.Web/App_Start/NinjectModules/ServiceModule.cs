using Ninject.Modules;
using Ninject.Web.Common;
using TeamTools.Logic.Services;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Web.App_Start.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IImageHelper>().To<ImageHelper>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<IMapperService>().To<MapperService>().InRequestScope();
            this.Bind<INoteService>().To<NoteService>().InRequestScope();
        }
    }
}