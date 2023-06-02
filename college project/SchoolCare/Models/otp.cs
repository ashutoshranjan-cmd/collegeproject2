using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolCare.Models
{
    public class otp
    {
        [Required]
        public string Email { get; set; }
    }
}