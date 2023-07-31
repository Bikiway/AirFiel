using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class AccountViewModel : Users
    {
        [Display(Name = "Profile Image")]
        public IFormFile ImageProfileUser { get; set; }
    }
}
