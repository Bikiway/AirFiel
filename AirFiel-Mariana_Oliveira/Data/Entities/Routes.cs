using System;
using System.Collections;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Routes : IEntity
    {
        public int Id { get; set; }

        public IEnumerable<RoutesDetails> Items { get; set; } //Lista da RoutesDetails.

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string AirplaneName { get; set; }

        public string Pilot { get; set; }

        public string CoPilot { get; set; }
        
        public double FullPrice { get; set; }

        public DateTime Depart { get; set; }

        public DateTime Return { get; set; }


    }
}
