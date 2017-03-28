using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WheelsShop.App.App_Start;
using WheelsShop.Data;
using WheelsShop.Data.Migrations;

namespace WheelsShop.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WheelsShopContext, Configuration>());

            MapperConfig.ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
