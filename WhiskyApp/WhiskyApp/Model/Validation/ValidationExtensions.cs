using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model.Validation
{
    public static class ValidationExtensions
    {
        //Denna metod är en utökning av klassen LabelBrandsDAL, medmera, 

        //this object gör så vi får på objektet istället för klassen 
        public static bool Validate(this object instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }


    }
}

