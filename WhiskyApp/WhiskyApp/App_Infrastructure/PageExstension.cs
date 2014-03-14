using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WhiskyApp
{
    public static class PageExstension
    {
        public static object getTempData(this Page page, string key)
        {
           var value = page.Session[key];
           page.Session.Remove(key);
           return value;
        }
        public static void setTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}