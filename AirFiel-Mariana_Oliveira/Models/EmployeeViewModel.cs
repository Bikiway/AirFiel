using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class EmployeeViewModel : Employees
    {
        [Display(Name = "Profile Image")]
        public IFormFile ImageProfile { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
