using Ganesha.Data;
using Ganesha.Web.Mappings;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ganesha.Web {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var context = new ApplicationDbContext();
            ApplicationInitializeDb.Seed(context);

            AutoMapperConfiguration.Configure();

            UnityConfig.GetConfiguredContainer();
        }
    }
}
