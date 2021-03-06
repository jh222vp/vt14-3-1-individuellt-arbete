﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhiskyApp.Model;

namespace WhiskyApp.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        //Fältet _service
        private Service _service;
        private int id;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AddUserSuccess"] as bool? == true)
            {
               
                Session.Remove("AddUserSuccess");
            }
        }

        public IEnumerable<LabelBrands> WhiskyListView_GetData()
        {
            return Service.GetWhiskys();
        }

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
                Response.Redirect("~/Pages/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle tas bort", BrandID)); ;
            }
        }



        public void ContactListView_InsertItem(LabelBrands labelBrands)
        {
            try
            {
                Service.SaveLabelBrands(labelBrands);
                Session["AddUserSuccess"] = true;
                //Redirecten skickar oss vidare till defaultsidan så det inte sker en ny postback
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakten skapades");
            }
        }






        
        // The id parameter name should match the DataKeyNames value set on the control
        public void WhiskyListView_UpdateItem(int brandID)
        {
            var item = Service.GetlabelBrand(brandID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", brandID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveLabelBrands(item);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void WhiskyModelListView_DeleteItem(int ModelID)
        {
            try
            {
               
                Service.DeleteModelWhisky(ModelID);
                Response.Redirect("~/Pages/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle tas bort", ModelID)); ;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void WhiskyModelListView_UpdateItem(int modelID)
        {
            id = modelID;
            var item = Service.GetWhiskyModel(modelID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", modelID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveModel(item);
            }
        }


        // The id parameter name should match the DataKeyNames value set on the control
        public void BottleListView_UpdateItem(int BottleID)
        {
            var item = Service.GetBottle(BottleID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", BottleID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveBottleProperties(item);
            }
        }
    }
}