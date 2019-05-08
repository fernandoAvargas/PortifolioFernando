using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PortifolioWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Principal",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Principal", action = "Inicio", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Consultoria",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Consultoria", action = "Inicio", id = UrlParameter.Optional }
          );

        }
    }
}
