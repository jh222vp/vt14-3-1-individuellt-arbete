using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model.BottleTable
{
    public class Bottle
    {
        public int BottleID { get; set; }

        public int BrandID { get; set; }

        public int ModelID { get; set; }

        [Required(ErrorMessage = "En år adress måste anges")]
        public int Year { get; set; }

        [Required(ErrorMessage = "En pris adress måste anges")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "En mängd adress måste anges")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "En procent adress måste anges")]
        public decimal Percents { get; set; }
    }
}