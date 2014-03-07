using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhiskyApp.Model;

namespace WhiskyApp.Pages.AddLabelBrandWhisky.AddModelWhisky
{
    public partial class ModelWhiskyAddd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Model.WhiskyModel> AddWhiskyModelView_GetData()
        {
            return Service.GetWhiskyModel();
        }

        public IEnumerable<LabelBrands> AddWhiskyView_GetData()
        {
            return Service.GetWhiskys();
        }

        public void AddWhiskyView_InsertModelItem(WhiskyModel whiskyModel)
        {
            try
            {
                Service.SaveModel(whiskyModel);
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