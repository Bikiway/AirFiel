using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Cities : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name="Country")]
        public string CountryName { get; set; }

        [Display(Name = "City Description")]
        public string Description { get; set; }

        [Display(Name = "Country Flag")]
        public string Flags { get; set; }

        [Display(Name = "Airport")]
        public string Airport { get; set; }

        [Display(Name="City")]
        public string FullCityName => $"{Name}, {CountryName}";
    }
}
