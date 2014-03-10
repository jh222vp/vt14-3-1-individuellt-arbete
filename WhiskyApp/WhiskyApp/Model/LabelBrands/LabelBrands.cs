using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model
{
    public class LabelBrands
    {
        public int BrandID { get; set; }
        

        [Required(ErrorMessage = "En Epost adress måste anges")]
        public string Brand { get; set; }

        public int GetWhiskyBrand { get; set; }
    }
}