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
            routes.MapPageRoute("AddWhsiky",
                "Ny/Whisky",
                "~/Pages/AddLabelBrandWhisky/AddWhisky.aspx");

            routes.MapPageRoute("Defualt",
                "",
                "~/Default.aspx");
        }
    }
}