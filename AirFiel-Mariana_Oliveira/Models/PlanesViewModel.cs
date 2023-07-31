using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class PlanesViewModel : Airplanes
    {
        [Display(Name = "Plane Image")]
        public IFormFile ImageFile { get; set; }
    }
}
