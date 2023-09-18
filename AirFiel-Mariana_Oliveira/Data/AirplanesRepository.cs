using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class AirplanesRepository : GenericRepository<Airplanes>, IAirplanesRepository
    {
        private readonly DataContext _dataContext;
        public AirplanesRepository(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }

        public IQueryable<Airplanes> GetAllWithUsers()
        {
            return _dataContext.airplanes.Include(p => p.users);
        }


        public IEnumerable<SelectListItem> GetComboAirplanes()
        {
            var list = _dataContext.airplanes.Select(p => new SelectListItem
            {
                Text = p.NamePlusCapacity,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Plane)",
                Value = "0"
            });

            return list;
        }
    }
}
