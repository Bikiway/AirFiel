﻿using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class CitiesRepository : GenericRepository<Cities>, ICitiesRepository
    {
        private readonly DataContext _dataContext;
        public CitiesRepository(DataContext dataContext) : base(dataContext) 
        {

            _dataContext = dataContext;

        }

        public IQueryable<Cities> GetAllWithUsers()
        {
            return _dataContext.City.Include(p => p.Users);
        }


        //ComboBox da view das Routes
        public IEnumerable<SelectListItem> GetComboCities()
        {
            var list = _dataContext.City.Select(p => new SelectListItem
            {
                Text = p.FullAirportAndCityName,
                Value = p.Id.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a City)",
                Value = "0",
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCountriesAndCities()
        {
            var list = _dataContext.City.Select(p => new SelectListItem
            {
                Text = p.FullCityName,
                Value = p.Id.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select)",
                Value = "0",
            });

            return list;
        }
    }
}
