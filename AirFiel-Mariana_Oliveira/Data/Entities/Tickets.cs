using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Tickets : IEntity
    {
        public  int Id { get; set; }

        #region
        //Client Info
        [Required]
        [Display(Name ="First Name")]
        public string ClientFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string ClientLastName { get; set; }

        [Required]
        [Display(Name = "User Name or Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        #endregion

        public string CC { get; set; }

        public string NIF { get; set; }

        public IEnumerable<TicketsDetails> Items { get; set; } //Ligação com a tabela TicketDetails.

        public int? SeatNumber1Class { get; set; }

        public int? SeatsNumber2Class { get; set; }


        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuantityOfPassengers => Items == null ? 0 : Items.Sum(i => i.QuantityOfPassengers);




        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TotalPrice => Items == null ? 0 : Items.Sum(i => i.TotalPrice);


        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime DeliveryDate { get; set; }


        #region
        //Passengers
        [Display(Name = "Fly First Class")]
        public int? PassengersFirstClass { get; set; }


        [Display(Name = "Fly Second Class")]
        public int? PassengersSecondClass { get; set; }

        #endregion


        #region 
        //Capacities
        public int capacityReduced1 { get; set; }

        public int capacityReduced2 { get; set; }

        public int FullCapacity => capacityReduced1 + capacityReduced2;
        #endregion


        //Counts for passengers

        public int? FirstClassTotal => capacityReduced1 - PassengersFirstClass;

        public int? SecondClassTotal => capacityReduced2 - PassengersSecondClass;

        public int? Total => FirstClassTotal - SecondClassTotal;

        public int? UpdateCapacityInRoutes => FullCapacity - Total;



        //Routes
        public string Origin { get; set; }

        public string Destination { get; set; }

        public string newUserId { get; set; }

        public DateTime Depart { get; set; }

        public DateTime Return { get; set;}

        [Required]
        public int routesId { get; set; }


        [Required]
        public Users users { get; set; }


    }
}
