using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhiskyApp.Model;

namespace WhiskyApp.Pages.AddLabelBrandWhisky.AddBottle
{
    public partial class BottlePropertyAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Model.BottleTable.Bottle> AddWhiskyBottleView_GetData()
        {
            return Service.GetBottleInfo();
        }
        public void AddBottleWhiskyView_InsertItem(Model.BottleTable.Bottle bottle)
        {
            try
            {
                Service.SaveBottleProperties(bottle);
                Session["AddUserSuccess"] = true;
                //Redirecten skickar oss vidare till defaultsidan så det inte sker en ny postback
                //Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakten skapades");
            }
        }


    }
}