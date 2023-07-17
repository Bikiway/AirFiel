using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Tickets : IEntity
    {
        public  int Id { get; set; }

        [Display(Name = "Número")]
        public int TicketNumber { get; set; }

        [Display(Name = "Letra")]
        public string TicketLetter { get; set; }


        public string FullSeat => $"{TicketNumber}{TicketLetter}";
    }
}
