using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Airplanes : IEntity
    {
        public int Id { get; set; }


        [Display(Name= "Airplane Name")] 

        public string Name { get; set; }

        [Display(Name = "Total of Classes")]
        public int HowManyClasses { get; set; }

        [Display(Name = "First Class Capacity")]
        public string Capacity1 { get; set; }

        [Display(Name = "Second Class Capacity")]
        public string Capacity2 { get; set; }

        public string Fullcapacity => $"{Capacity1} + {Capacity2}";

        [Display(Name = "Airplane Image")]
        public string ImagePlane { get; set; }

        public Users users { get; set; }
    }
}
