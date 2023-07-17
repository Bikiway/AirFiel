namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class RoutesDetails : IEntity
    {
        public int Id { get; set; }

        public Airplanes airplanes { get; set; }

        public Employees employees { get; set; }

        public Cities citys { get; set; }

        public double FullPrice { get; set; }

        public int TravelQuantity { get; set; }


    }
}
