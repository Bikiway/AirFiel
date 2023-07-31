using Microsoft.AspNetCore.Identity;
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


        [Display(Name = "Profile Image")]
        public string ImageUserProfile { get; set; }
    }
}
