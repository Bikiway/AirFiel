using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using AirFiel_Mariana_Oliveira.Data.Entities;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class TicketsViewModel
    {
        public int Id { get; set; }
        public int routesId { get; set; }

        public int PricePerTicketId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Age")]
        [MaxLength(3, ErrorMessage = "The field {0} only can contain {1} characters length")]
        public string Age { get; set; }


        [Required]
        [MaxLength(10)]
        public string CC { get; set; }

        [Required]
        [MaxLength(10)]
        public string NIF { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity must be a positive number")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Passengers { get; set; }


        [Display(Name = "Fly First Class")]
        public int PassengersFirstClass { get; set; }


        [Display(Name = "Fly Second Class")]
        public int PassengersSecondClass { get; set; }


        [Display(Name = "Ida e Volta")]
        public bool IdaEVolta { get; set; }


        public IEnumerable<TicketsDetailsTemp> Items { get; set; }


        public int SeatNumber1 { get; set; }

        public int SeatNumber2 { get; set; }

        public int NumberOfSeats1 { get; set; }

        public int NumberOfSeats2 { get; set; }

        public int SeatId1 { get; set; }

        public int SeatId2 { get;set; }

    }
}
