using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using AirFiel_Mariana_Oliveira.Data.Entities;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class UserSpaceViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string CC { get; set; }

        public string NIF { get; set; }

        public int routesId { get; set; }

        public int ticketId { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string Depart { get; set; }

        public string Return { get; set; }

        public int PassengersFirstClass { get; set; }

        public int PassengersSecondClass { get; set; }

        public double TotalPrice { get; set; }
    }
}
