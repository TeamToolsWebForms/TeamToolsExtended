using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamTools.Web.Startup))]
namespace TeamTools.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
