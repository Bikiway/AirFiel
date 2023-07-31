using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class AddRouteViewModel
    {
        [Display(Name ="Planes")]
        [Range(1, int.MaxValue, ErrorMessage ="You must choose a airplane.")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Must be a positive number.")]
        public int QuantityOfTravels { get; set; }
        
        //ComboBox dos aviões
        public IEnumerable<SelectListItem> Plane { get; set; }

        //ComboBox das cidades de Origem
        public IEnumerable<SelectListItem> Origem { get; set; }


        //ComboBox das cidades de Destino
        public IEnumerable<SelectListItem> Destino { get; set; }

        //ComboBox dos Pilotos
        public IEnumerable<SelectListItem> Pilot { get; set; }

        //ComboBox do Co-pilot
        public IEnumerable<SelectListItem> CoPilot { get; set; }

        //Full-Price
        [Range(0.0001, double.MaxValue, ErrorMessage ="Must be a positive number")]
        public double FullPrice { get; set; }



    }
}
