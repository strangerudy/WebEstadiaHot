using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEstadiaHot.Startup))]
namespace WebEstadiaHot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
