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
        [EmailAddress(ErrorMessage = "Eposten måste vara korrekt")]
        public int Year { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        [EmailAddress(ErrorMessage = "Eposten måste vara korrekt")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        [EmailAddress(ErrorMessage = "Eposten måste vara korrekt")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        [EmailAddress(ErrorMessage = "Eposten måste vara korrekt")]
        public decimal Percents { get; set; }
    }
}