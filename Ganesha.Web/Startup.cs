using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ganesha.Web.Startup))]
namespace Ganesha.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
