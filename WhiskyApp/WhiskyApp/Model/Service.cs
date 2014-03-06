using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model
{
    public class Service
    {
        
        private static LabelBrandsDAL _labelBrandsDAL;

       
        public static LabelBrandsDAL LabelBrandsDAL
        {
            get { return _labelBrandsDAL ?? (_labelBrandsDAL = new LabelBrandsDAL()); }
        }

        public static IEnumerable<LabelBrands> GetWhiskys()
        {
            return LabelBrandsDAL.GetWhiskyBrands();
        }
        public static IEnumerable<WhiskyModel> GetWhiskyModel()
        {
            return ModelDAL.GetWhiskyModels();
        }
        public static IEnumerable<BottleTable.Bottle> GetBottleInfo()
        {
            return BottleTable.BottleDAL.GetBottleInfo();
        }


        public static void DeleteLabelBrand(LabelBrands labelbrandsID)
        {
            DeleteLabelBrand(labelbrandsID.BrandID);
        }

        public static void DeleteLabelBrand(int brandID)
        {
            LabelBrandsDAL.DeleteLabelBrand(brandID);
        }

    }
}