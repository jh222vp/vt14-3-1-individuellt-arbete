using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model
{
    public class WhiskyModel
    {
        public int ModelID { get; set; }

        [Required(ErrorMessage = "En Epost adress måste anges")]
        [EmailAddress(ErrorMessage = "Eposten måste vara korrekt")]
        public string Model { get; set; }
    }
}