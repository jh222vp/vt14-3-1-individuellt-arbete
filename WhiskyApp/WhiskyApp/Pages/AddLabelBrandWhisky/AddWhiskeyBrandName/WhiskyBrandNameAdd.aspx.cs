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
        //Hämtar alla whiskynamn
        public IEnumerable<LabelBrands> AddWhiskyView_GetData()
        {
            return Service.GetWhiskys();
        }

        //Insert för nytt whiskynamn
        public void AddWhiskyView_InsertItem(LabelBrands labelBrands)
        {
            try
            {
                Service.SaveLabelBrands(labelBrands);
                Page.setTempData("Success", "Märket lades till");


                //Redirecten skickar oss vidare till defaultsidan så det inte sker en ny postback
                Response.RedirectToRoute("WhiskyBrand");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakten skapades");
            }
        }
    }
}