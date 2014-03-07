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

        [Required(ErrorMessage = "En Epost adress måste anges")]
        public int Year { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        public decimal Percents { get; set; }
    }
}