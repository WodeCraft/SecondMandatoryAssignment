using System.Web.Mvc;
using System.Web.Routing;

namespace MbmStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ControllerRoute",
                url: "{controller}",
                defaults: new { controller = "Catalogue", action = "Index", category = (string)null, page = 1 }
            );

            routes.MapRoute(
                name: "PagingRoute",
                url: "{controller}/Page{page}",
                defaults: new { controller = "Catalogue", action = "Index", category = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "CategoryRoute",
                url: "Catalogue/{category}",
                defaults: new { controller = "Catalogue", action = "Index", page = 1 }
            );

            routes.MapRoute(
                name: "CategoryPagingRoute",
                url: "Catalogue/{category}/Page{page}",
                defaults: new { controller = "Catalogue", action = "Index" },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
