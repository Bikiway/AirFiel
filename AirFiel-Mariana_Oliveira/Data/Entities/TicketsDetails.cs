using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class TicketsDetails : IEntity
    {
        public int Id { get; set; }

        public string FullName => $"{FirstName} {LastName}";


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        public int routesId { get; set; }

        [Required]
        public int userId { get; set; }


        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuantityOfPassengers { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double PricePerTicket { get; set; }


        public double TotalPrice => PricePerTicket * (double)QuantityOfPassengers;
    }
}
