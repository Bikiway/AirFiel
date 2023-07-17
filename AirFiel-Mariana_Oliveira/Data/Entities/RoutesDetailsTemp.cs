namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class RoutesDetailsTemp :IEntity
    {
        public int Id { get; set; }

        public Airplanes airplanes { get; set; }

        public Cities cities { get; set; }

        public Employees employees { get; set; }

        public int TravelQuantity { get; set; } 
    }
}
