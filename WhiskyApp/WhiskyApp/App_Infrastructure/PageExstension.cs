using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WhiskyApp.App_Infrastructure
{
    public static class PageExstension
    {
        public static object getTempData(this Page page, string key, object value)
        {
           //page.Session[key]
           return value;
        }
    }
}