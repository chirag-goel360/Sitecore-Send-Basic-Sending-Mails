using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SitecoreSend.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please Enter your Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter your Email Address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter the List of Participants for Mail")]
        [Display(Name = "Participants Email")]
        public string EmailList { get; set; }

        [Required(ErrorMessage = "Please Enter your Message")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}