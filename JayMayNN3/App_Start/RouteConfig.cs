using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JayMayNN3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
