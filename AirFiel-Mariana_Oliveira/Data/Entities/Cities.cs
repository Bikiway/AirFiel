using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Cities
    {
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name = "City Description")]
        public string Description { get; set; }

        [Display(Name = "Country Flag")]
        public string Flags { get; set; }
    }
}
