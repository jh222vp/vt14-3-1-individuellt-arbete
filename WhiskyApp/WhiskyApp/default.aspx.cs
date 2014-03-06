using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhiskyApp.Model;

namespace WhiskyApp
{
    public partial class _default : System.Web.UI.Page
    {
        //Fältet _service
        //private Service _service;

        //private Service Service
        //{
        //    get { return _service ?? (_service = new Service()); }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<LabelBrands> WhiskyListView_GetData()
        {
            return Service.GetWhiskys();
        }



        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<WhiskyModel> WhiskyModelListView_GetData()
        {
            return Service.GetWhiskyModel();
        }





        public IEnumerable<WhiskyApp.Model.BottleTable.Bottle> BottleListView_GetData()
        {
            return Service.GetBottleInfo();
        }



        public void ContactListView_DeleteItem(int BrandID)
        {
            try
            {

                Service.DeleteLabelBrand(BrandID);
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle tas bort", BrandID)); ;
            }
        }

    }
}