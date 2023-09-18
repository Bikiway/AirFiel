using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface IAirplanesRepository : IGenericRepository<Airplanes>
    {
        public IQueryable<Airplanes> GetAllWithUsers();

        //(int capacity1, int capacity2) GetCapacity(int airplaneId);

        IEnumerable<SelectListItem> GetComboAirplanes();
    }
}
