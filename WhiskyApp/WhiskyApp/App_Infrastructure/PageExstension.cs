using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WhiskyApp
{
    public static class PageExstension
    {
        //getTempData hämtar ut en session med key som parameter
        public static object getTempData(this Page page, string key)
        {
           var value = page.Session[key];
            //Tar bort sessionen efter att vi hämtat den ovan.
           page.Session.Remove(key);
           return value;
        }
        //Skapar sessionen med namnet key och value är värdet som finns i
        public static void setTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}