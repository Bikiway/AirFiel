using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using AirFiel_Mariana_Oliveira.Data.Entities;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class TicketsViewModel
    {
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


        [Display(Name = "Ida e Volta")]
        public bool IdaEVolta { get; set; }

    }
}
