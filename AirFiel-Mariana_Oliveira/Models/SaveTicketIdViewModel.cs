using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class SaveTicketIdViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime DeliveryDate { get; set; }
    }
}
