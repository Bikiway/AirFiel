using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class AddRouteViewModel
    {
        [Display(Name ="Planes")]
        [Range(1, int.MaxValue, ErrorMessage ="You must choose an airplane.")]
        public int AirplaneId { get; set; }


        [Display(Name = "Origin")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a city airport.")]
        public int OriginId { get; set; }


        [Display(Name = "Destination")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a city airport.")]
        public int DestinationId { get; set; }


        [Display(Name = "Pilot")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a pilot.")]
        public int PilotsId { get; set; }


        [Display(Name = "Co-Pilot")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a co-pilot.")]
        public int CoPilotsId { get; set; }



        [Required]
        [Display(Name = "Date/Time Depart")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Depart { get; set; }


        [Required]
        [Display(Name = "Date/Time Return")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Return { get; set; }



        [Range(1, int.MaxValue, ErrorMessage ="Must be a positive number.")]
        public int QuantityOfTravels { get; set; }


       public int priceId { get; set; }      


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

    }
}
