using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        [MaxLength(3, ErrorMessage = "The field {0} only can contain {1} characters length")]
        public string Age { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length")]
        public string PhoneNumber { get; set; }

    }
}
