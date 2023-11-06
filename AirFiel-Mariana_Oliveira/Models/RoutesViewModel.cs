using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class RoutesViewModel : Routes
    {
        public string NameOfAirplane { get; set; }

        public string OriginCity { get; set; }

        public string DestinationCity { get; set; }

        public DateTime DepartCity { get; set; }

        public DateTime ReturnCity { get; set; }

        public string PilotName { get; set; }

        public string CoPilotName { get; set; }

        public double GetFullPrices { get; set; }

        public int CapacityFirst { get; set; }

        public int CapacitySecond { get; set; }

        public int GetOriginCity { get; set; }

        public int GetDestinationCity { get; set;}
    }
}
