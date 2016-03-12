using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NamCkiku
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddCart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewDetail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Products", action = "ViewDetailProduct", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Finish",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Finish", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Category",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Products", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
