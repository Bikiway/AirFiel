using System;
using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Prices 
    { 
        private readonly Airplanes _airplane;
        private readonly Routes _routes;
        public Prices(Airplanes airplanes, Routes routes)
        {
            _airplane = airplanes;
            _routes = routes;
        }


        //Preço sem a margem de lucro
        public double FullPriceWithoutProfit => Convert.ToDouble(_routes.FullPrice);


        //Preço com a margem de lucro
        public double FullPriceWithProfit => PriceClass1 + PriceClass2;


        //Price per ticket
        public double PricePerTicket => FullPriceWithoutProfit / Convert.ToDouble(_airplane.Fullcapacity); 



        //First Class Total Value
        public double PriceClass1 => PricePerTicket * Convert.ToDouble(_airplane.Capacity1) * 3;


        //Second Class Total Value
        public double PriceClass2 => PricePerTicket * Convert.ToDouble(_airplane.Capacity2) * 2;


        //Prices per seat in different classes
        public double PricePerSeatInFirstClass => PriceClass1 / Convert.ToDouble(_airplane.Capacity1);

        public double PricePerSeatInSecondClass => PriceClass2 / Convert.ToDouble(_airplane.Capacity2);


        //Discount For First Client and 10th uses for travelling.
        public double Discounts { get; set; }
    }
}
