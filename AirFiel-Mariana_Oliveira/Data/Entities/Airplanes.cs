using System;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Airplanes : IEntity
    {
        public int Id { get; set; }


        [Display(Name = "Airplane Name")]

        public string Name { get; set; }


        [Display(Name = "Total of Classes")]
        [MaxLength(1, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int HowManyClasses 
        { get { return HowManyClasses; }
            set { if (value < 3)
                { _ = HowManyClasses; } } }



        [Display(Name = "First Class Capacity")]
        public int Capacity1 { get; set; }

        [Display(Name = "Second Class Capacity")]
        public int Capacity2 { get; set; }

        public int Fullcapacity => Capacity1 + Capacity2;

        public string NamePlusCapacity => $"{Name} + {Fullcapacity}";

        [Display(Name = "Airplane Image")]
        public string ImagePlane { get; set; }


        public Users users { get; set; }
    }
}
