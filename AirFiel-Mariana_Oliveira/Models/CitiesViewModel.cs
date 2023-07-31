using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class CitiesViewModel : Cities
    {
        [Display(Name = "City or Country Image")]
        public IFormFile ImageCity { get; set; }
    }
}
