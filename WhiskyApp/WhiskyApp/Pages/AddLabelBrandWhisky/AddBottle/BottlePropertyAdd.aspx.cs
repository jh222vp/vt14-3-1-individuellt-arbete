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
            if (Session["UploadedPropertiesSuccess"] as bool? == true)
            {
                UploadSuccessed.Visible = true;
                Session.Remove("UploadedPropertiesSuccess");
            }
        }
        public IEnumerable<Model.BottleTable.Bottle> AddWhiskyBottleView_GetData()
        {
            return Service.GetBottleInfo();
        }
        public IEnumerable<Model.WhiskyModel> AddWhiskyModelView_GetData()
        {
            return Service.GetWhiskyModel();
        }
        public IEnumerable<LabelBrands> AddWhiskyView_GetData()
        {
            return Service.GetWhiskys();
        }

        public DropDownList BrandDropDown { get; set; }
        public DropDownList ModelDropDown { get; set; }

        public void AddBottleWhiskyView_InsertItem(Model.BottleTable.Bottle bottle)
        {
            try
            {
                Service.SaveBottleProperties(bottle);
                Session["UploadedPropertiesSuccess"] = true;
                
                
                //Redirecten skickar oss vidare till defaultsidan så det inte sker en ny postback
                Response.Redirect("~/Pages/AddLabelBrandWhisky/AddBottle/BottlePropertyAdd.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakten skapades");
            }
        }

        public IEnumerable<LabelBrands> WhiskyListView_GetData()
        {
            return Service.GetWhiskys();
           
        }
        public IEnumerable<WhiskyModel> WhiskyListModelView_GetData()
        {
            return Service.GetWhiskyModel();

        }
    }
}