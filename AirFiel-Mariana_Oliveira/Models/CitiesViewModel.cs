using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class CitiesViewModel : Cities
    {
        [Display(Name = "Flags")]
        public IFormFile FlagsFile { get; set; }

        public IEnumerable<SelectListItem> AllFlags { get; set; }

        public IEnumerable<SelectListItem> City { get; set; }
    }
}
