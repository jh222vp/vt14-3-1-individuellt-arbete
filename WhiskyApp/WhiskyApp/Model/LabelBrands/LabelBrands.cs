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
        

        [Required(ErrorMessage = "Ett märke måste anges")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Ett märke måste anges")]
        public int GetWhiskyBrand { get; set; }
    }
}