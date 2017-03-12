using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "All customers ordered",
                url: "customers/all/{order}",
                defaults: new { controller = "Customers", action = "All", order = "ascending" },
                constraints: new {order = @"ascending|descending"});

            routes.MapRoute(
                name: "All cars from make",
                url: "cars/{make}",
                defaults: new { controller = "Cars", action = "All" });

            routes.MapRoute(
               name: "Filter suppliers",
               url: "suppliers/{filter}",
               defaults: new { controller = "Suppliers", action = "All" });
        }
    }
}
