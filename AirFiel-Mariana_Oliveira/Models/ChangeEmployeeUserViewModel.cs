using AirFiel_Mariana_Oliveira.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class ChangeEmployeeUserViewModel : Employees
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage ="The field {0} only can contain {1} characters lenght.")]
        public string Age { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string Experience { get; set; }

        
        public string ProfileImage { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")] //Validar a password.
        public string Confirm { get; set; }
    }
}
