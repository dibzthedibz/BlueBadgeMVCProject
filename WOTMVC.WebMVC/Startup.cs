using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WOTMVC.WebMVC.Startup))]
namespace WOTMVC.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
