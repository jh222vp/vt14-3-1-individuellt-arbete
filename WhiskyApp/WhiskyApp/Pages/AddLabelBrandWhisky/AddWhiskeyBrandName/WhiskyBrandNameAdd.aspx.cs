using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhiskyApp.Model;

namespace WhiskyApp.Pages.AddLabelBrandWhisky.AddWhiskeyBrandName
{
    public partial class WhiskyBrandNameAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Hämtar all whisky
        public IEnumerable<LabelBrands> AddWhiskyView_GetData()
        {
            return Service.GetWhiskys();
        }
        //Insert för ny whisky
        public void AddWhiskyView_InsertItem(LabelBrands labelBrands)
        {
            try
            {
                Service.SaveLabelBrands(labelBrands);
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