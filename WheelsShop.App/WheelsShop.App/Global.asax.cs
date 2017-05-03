using System;
using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Web;
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
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WheelsShopContext, Configuration>());
            MapperConfig.ConfigureMappings();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(decimal), new ModelBinder.DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new ModelBinder.DecimalModelBinder());
        }
    }
}
