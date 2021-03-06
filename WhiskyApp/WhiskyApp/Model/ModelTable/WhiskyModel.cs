﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model
{
    public class WhiskyModel
    {
        public int ModelID { get; set; }

        public int BrandID { get; set; }

        [Required(ErrorMessage = "En model adress måste anges")]
        public string Model { get; set; }

    }
}