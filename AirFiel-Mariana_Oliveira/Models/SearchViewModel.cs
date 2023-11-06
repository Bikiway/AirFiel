using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class SearchViewModel
    {
        public int ToCountryCityID { get; set; }  //Gets the Destination Country/city


        public int FromCountryCityId { get; set; }  //Gets the Origin Country/city

        public DateTime? FlightDate { get; set; } //Gets the date

        public IEnumerable<SelectListItem> From { get; set; }

        public IEnumerable<SelectListItem> To { get; set; }

    }
}
