using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhiskyApp.Model.Validation;
using WhiskyApp.Model;
using System.ComponentModel.DataAnnotations;

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

        //Undersöker värdet egenskapen ContactId. Har ContactId värdet 0 är det en ny post. Annars en uppdatering.
        public static void SaveLabelBrands(LabelBrands labelBrands)
        {

            ICollection<ValidationResult> validationResults;
            if (!labelBrands.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet kunde inte valideras");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }


            if (labelBrands.BrandID == 0)
            {
                LabelBrandsDAL.InsertWhisky(labelBrands);
            }
            else
            {
                //LabelBrandsDAL.UpdateContact(labelBrands);
            }
        }

    }
}