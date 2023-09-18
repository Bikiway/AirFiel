using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

  
        [Required]
        [MaxLength(3, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string Age { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Profession")]
        public string Experience { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")] //Validar a password.
        public string Confirm { get; set; }
    }
}
