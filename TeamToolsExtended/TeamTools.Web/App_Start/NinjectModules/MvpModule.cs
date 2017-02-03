using System;
using System.Linq;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using WebFormsMvp;
using WebFormsMvp.Binder;
using TeamTools.Web.App_Start.MvpFactoryConfig;
using TeamTools.Web.App_Start.MvpFactoryConfig.Contracts;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;

namespace TeamTools.Web.App_Start.NinjectModules
{
    public class MvpModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenterFactory>().To<CustomPresenterFactory>().InSingletonScope();
            this.Bind<IPresenter>()
                .ToMethod(GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null, null));
            this.Bind<IProfileHomePresenter>().To<ProfileHomePresenter>();
            this.Bind<IProfileHomeProjectsPresenter>().To<ProfileHomeProjectsPresenter>();
            this.Bind<ICreateNotePresenter>().To<CreateNotePresenter>();
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = parameters[0].GetValue(context, null) as Type;
            var viewType = parameters[1].GetValue(context, null) as Type;
            var viewInstance = parameters[2].GetValue(context, null) as IView;
            var viewInterface = viewType.GetInterfaces().FirstOrDefault(i => i.Name.Contains("View") && !i.Name.Contains("IView"));

            this.BindInterface(viewInterface, viewInstance);
            return context.Kernel.Get(presenterType) as IPresenter;
        }

        private void BindInterface(Type viewType, IView view)
        {
            var isInterfaceBinded = this.Kernel.GetBindings(viewType).Any();

            if (isInterfaceBinded)
            {
                this.Rebind(viewType).ToMethod(context => view);
                return;
            }

            this.Bind(viewType).ToMethod(context => view);
        }
    }
}