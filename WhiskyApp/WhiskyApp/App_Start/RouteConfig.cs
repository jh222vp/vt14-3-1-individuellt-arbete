using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WhiskyApp.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ModelWhisky",
                "Ny/ModelWhisky",
                "~/Pages/AddLabelBrandWhisky/AddModelWhisky/ModelWhiskyAddd.aspx");

            routes.MapPageRoute("WhiskyBrand",
                "Ny/WhiskyBrand",
                "~/Pages/AddLabelBrandWhisky/AddWhiskeyBrandName/WhiskyBrandNameAdd.aspx");

            routes.MapPageRoute("WhiskyBottle",
                "Ny/WhiskyBottle",
                "~/Pages/AddLabelBrandWhisky/AddBottle/BottlePropertyAdd.aspx");

            routes.MapPageRoute("Default",
                "",
                "~/Pages/Default.aspx");
        }
    }
}