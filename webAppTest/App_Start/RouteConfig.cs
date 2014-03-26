using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webAppTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // Default action: RecipeController
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new           
                {
                    controller = "Recipe", 
                    action = "Index", 
                    id = UrlParameter.Optional 
                }                                   // what is an annonimous type?
            );
        }
    }
}