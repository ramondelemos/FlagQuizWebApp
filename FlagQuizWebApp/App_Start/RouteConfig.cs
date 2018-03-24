using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlagQuizWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Flags",
                "Flags/",
                new { controller = "Flags", action = "Index" }
            );

            routes.MapRoute(
                "Flag",
                "Flags/{id}",
                new { controller = "Flags", action = "Flag" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Flags", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
