using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = false)]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Profile Image")]
        public string ImageUserProfile { get; set; }


        //Only for Employees
        
        [MaxLength(2, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string Age { get; set; }

        
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string Experience { get; set; }
    }
}
