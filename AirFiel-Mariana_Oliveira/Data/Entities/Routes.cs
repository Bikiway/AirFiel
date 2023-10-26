using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Routes : IEntity
    {
        public readonly Airplanes _airplanes;

        public int Id { get; set; }


        [Display(Name = "Airplane")]
        public Airplanes AirplaneName { get; set; }


        [Display(Name = "Origin")]
        public Cities Origin { get; set; }


        [Display(Name = "Destination")]
        public Cities Destination { get; set; }

        public ICollection<RoutesDetails> AssociatedRoutes { get; set; }


        public IEnumerable<RoutesDetails> Items { get; set; } //Lista da RoutesDetails.
        public int Lines => Items == null ? 0 : Items.Count();


        [Required]
        [Display(Name = "Date/Time Depart")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Depart { get; set; }


        [Required]
        [Display(Name = "Date/Time Return")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Return { get; set; }


        [Display(Name = "Pilot's Name")]
        public Employees Pilot { get; set; }

        [Display(Name = "Co-Pilot's Name")]
        public Employees CoPilot { get; set; }


        [Required]
        [Display(Name = "Full Value")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double FullPrice => Items == null ? 0 : Items.Sum(i => i.ValuePerMonth);   

        public double GetFullPrice { get; set; }

        [Required]
        [Display(Name = "Travels Per Month")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int TravelsPerMonth => Items == null ? 0 : Items.Sum(i => i.TravelsPerMonth);


        [Required]
        public Users users { get; set; }

        public int Capacity1 { get; set; }

        public int Capacity2 { get; set; }

        public int FullCapacity => Capacity1 + Capacity2;

        //ALL The Prices


        //Preço com a margem de lucro
        public double FullPriceWithProfits => PriceClass1 + PriceClass2;


        //Price per ticket
        public double PricePerTicket => (double)FullPrice / Convert.ToDouble(FullCapacity);



        //First Class Total Value
        public double PriceClass1 => PricePerTicket * Convert.ToDouble(Capacity1) * 3;


        //Second Class Total Value
        public double PriceClass2 => PricePerTicket * Convert.ToDouble(Capacity2) * 2;


        //Prices per seat in different classes
        public double PricePerSeatInFirstClass => PriceClass1 / Convert.ToDouble(Capacity1);

        public double PricePerSeatInSecondClass => PriceClass2 / Convert.ToDouble(Capacity2);


        //Discount For First Client and 10th uses for travelling.
        public double Discounts { get; set; }


    }
}
