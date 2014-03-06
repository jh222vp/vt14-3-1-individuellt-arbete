using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model
{
    public class Service
    {
        //Fält
        private static LabelBrandsDAL _labelBrandsDAL;

        //Egenskap
        public static LabelBrandsDAL LabelBrandsDAL
        {
            get { return _labelBrandsDAL ?? (_labelBrandsDAL = new LabelBrandsDAL()); }
        }


        //public LabelBrands GetContact(int contactId)
        //{
        //    return LabelBrandsDAL.GetContact(contactId);
        //}

        public static IEnumerable<LabelBrands> GetWhiskys()
        {
            return LabelBrandsDAL.GetWhiskyBrands();
        }
        public static IEnumerable<WhiskyModel> GetWhiskyModel()
        {
            return ModelDAL.GetWhiskyModels();
        }
    }
}