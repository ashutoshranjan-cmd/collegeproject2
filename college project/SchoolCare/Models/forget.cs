﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCare.Models
{
    public class forget
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}