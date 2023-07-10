using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Prices
    {
        [Display(Name = "Full Price")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double FullPrice { get; set; }


        [Display(Name = "First Class Price")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double PriceClass1 { get; set; }


        [Display(Name = "Second Class Price")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double PriceClass2 { get; set; }



        [Display(Name ="Discout")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Discounts { get; set; }
    }
}
