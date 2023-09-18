using System;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class RoutesDetailsTemp : IEntity
    {
        public int Id { get; set; }

        public Users user { get; set; }

        [Required]
        public Airplanes airplanes { get; set; }

        [Required]
        public Cities originCities { get; set; }


        [Required]
        public Cities destinationCities { get; set; }

        [Required]
        public Employees pilotEmployees { get; set; }


        [Required]
        public Employees coPilotEmployees { get; set; }


        [Required]
        [Display(Name = "Date/Time Depart")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Depart { get; set; }


        [Required]
        [Display(Name = "Date/Time Return")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Return { get; set; }



        [Required]
        [Display(Name = "Full Value")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double FullPrice { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int TravelsPerMonth { get; set; }


        public double ValuePerMonth => FullPrice * ((int)TravelsPerMonth);
    }
}
