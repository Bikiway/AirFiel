using System;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class TicketsDetailsTemp : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string FullNAme => $"{FirstName} {LastName}";

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
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Passengers { get; set; }


        [Display(Name ="Ida e Volta")]
        public bool IdaEVolta { get; set; }


        [Display(Name = "Fly First Class")]
        public int? PassengersFirstClass { get; set; }


        [Display(Name = "Fly Second Class")]
        public int? PassengersSecondClass { get; set; }

        public int? SeatNumber1Class { get; set; }

        public int? SeatsNumber2Class { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double PricePerTicket { get; set; }

        public double TravelPrice => PricePerTicket * (double)Passengers;

        public int routeId { get; set; }

        public Routes routesId { get; set; }

        [Required]
        public Users user { get; set; }

    }
}
