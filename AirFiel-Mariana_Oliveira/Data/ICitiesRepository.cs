using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface ICitiesRepository : IGenericRepository<Cities>
    {
        public IQueryable<Cities> GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboCities();

        IEnumerable<SelectListItem> GetComboCountriesAndCities();
    }
}
