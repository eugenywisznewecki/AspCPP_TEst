using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _70322_Yushkevich
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                 name: "",
                 url: "menu",
                 defaults: new
                 {
                     controller = "Dish",
                     action = "List",
                     page = 1,
                     group = (string)null
                 });
            routes.MapRoute(
                 name: "",
                 url: "menu/page{page}",
                 defaults: new
                 {
                     controller = "Dish",
                     action = "List",
                     group = (string)null
                 },
                 constraints: new { page = @"\d+" });
            routes.MapRoute(
                 name: "",
                 url: "menu/{group}",
                 defaults: new
                 {
                     controller = "Dish",
                     action = "List",
                     page = 1
                 });
            routes.MapRoute(
                 name: "",
                 url: "menu/{group}/page{page}",
                 defaults: new { controller = "Dish", action = "List" },
                 constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }                    
                );
        }
    }
}
