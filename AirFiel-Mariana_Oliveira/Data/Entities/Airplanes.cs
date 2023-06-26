namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Airplanes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Classes { get; set; }

        public string Capacity1 { get; set; }

        public string Capacity2 { get; set; }

        public string Fullcapacity => $"{Capacity1} + {Capacity2}";
        
        public string ImagePlane { get; set; }


    }
}
