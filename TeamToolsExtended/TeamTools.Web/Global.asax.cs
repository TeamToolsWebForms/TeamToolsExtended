using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using WebFormsMvp.Binder;
using TeamTools.Web.App_Start;

namespace TeamTools.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // move configs later
            var presenterFactory = NinjectWebCommon.Kernel.Get<IPresenterFactory>();
            PresenterBinder.Factory = presenterFactory;
            DbConfig.Initialize();
            AutomapperConfig.CreateMapper();
        }
    }
}