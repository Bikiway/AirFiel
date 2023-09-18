using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;
using System.Linq;

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


        public IEnumerable<TicketsDetails> Items { get; set; } //Ligação com a tabela TicketDetails.




        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuantityOfPassengers => Items == null ? 0 : Items.Sum(i => i.QuantityOfPassengers);




        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TotalPrice => Items == null ? 0 : Items.Sum(i => i.TotalPrice);


        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime DeliveryDate { get; set; }


        public int capacityReduced1 { get; set; }

        public int capacityReduced2 { get; set; }

        public int UpdateCapacity => capacityReduced1 + capacityReduced2;

        public string newUserId { get; set; }

        [Required]
        public int routesId { get; set; }


        [Required]
        public Users users { get; set; }


    }
}
