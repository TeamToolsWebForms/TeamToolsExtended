using Ninject.Modules;
using Ninject.Web.Common;
using TeamTools.Services;
using TeamTools.Services.Contracts;
using TeamTools.Services.Helpers;
using TeamTools.Services.Helpers.Contracts;

namespace TeamTools.Web.App_Start.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IImageHelper>().To<ImageHelper>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<IMapperService>().To<MapperService>().InRequestScope();
        }
    }
}