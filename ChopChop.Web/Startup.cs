using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChopChop.Web.Startup))]
namespace ChopChop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
