using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SchoolCare.Models
{
    public class signup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Session { get; set; }
        [Required]
        public string Roll { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Bloodgroup { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public HttpPostedFileBase Photo { get; set; }

        [Required]
        public string About { get; set; }

      
    }
}