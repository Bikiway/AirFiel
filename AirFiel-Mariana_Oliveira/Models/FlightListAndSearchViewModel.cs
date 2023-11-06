using AirFiel_Mariana_Oliveira.Data.Entities;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class FlightListAndSearchViewModel
    {
        public IEnumerable<Routes> FlightsList { get; set; }

        public SearchViewModel searchViewModel { get; set; }
    }
}
