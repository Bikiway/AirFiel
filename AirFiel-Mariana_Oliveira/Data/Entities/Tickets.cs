namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Tickets
    {
        public int TicketNumber { get; set; }

        public string TicketLetter { get; set; }

        public string FullSeat => $"{TicketNumber}{TicketLetter}";
    }
}
