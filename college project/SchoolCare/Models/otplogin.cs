using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCare.Models
{
    public class otplogin
    {
        [Required]
        public string Number { get; set; }
    }
}