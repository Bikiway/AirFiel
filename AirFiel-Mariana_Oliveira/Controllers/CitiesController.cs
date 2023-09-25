using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.AspNetCore.Authorization;
using AirFiel_Mariana_Oliveira.Models;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ICitiesRepository _cityRepository;
        private readonly IImageHelper _imageHelper;

        public CitiesController(IImageHelper imageHelper, IUserHelper userHelper, ICitiesRepository repository, IConverterHelper converterHelper)
        {
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
            _cityRepository = repository;
        }

        // GET: Cities
        public IActionResult Index()
        {
            return View(_cityRepository.GetAllWithUsers().OrderBy(e => e.Id));
        }

        [Authorize(Roles = "Admin")]
        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }

            var cities = await _cityRepository.GetByIdAsync(id.Value);

            if (cities == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }

            return View(cities);
        }

        // GET: Cities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitiesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = model.CountryName;

                if (model.FlagsFile != null && model.FlagsFile.Length > 0)
                {
                    path = await _imageHelper.UploadImageAsync(model.FlagsFile, "flags");
                }

                var citys = _converterHelper.ToCities(model, path, true);

                citys.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _cityRepository.CreateAsync(citys);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: Cities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }

            var cities = await _cityRepository.GetByIdAsync(id.Value);

            if (cities == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }
            var model = _converterHelper.ToCitiesViewModel(cities);
            return View(model);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CitiesViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.CountryName;

                    if (model.FlagsFile != null && model.FlagsFile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.FlagsFile, "flags");
                    }

                    var cities = _converterHelper.ToCities(model, path, false);

                    cities.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _cityRepository.UpdateAsync(cities);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _cityRepository.ExistAsync(model.Id))
                    {
                        return new NotFoundViewResult("CityNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Cities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }

            var cities = await _cityRepository.GetByIdAsync(id.Value);

            if (cities == null)
            {
                return new NotFoundViewResult("CityNotFound");
            }

            return View(cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_cityRepository == null)
            {
                return Problem("Entity set 'DataContext.Cities' is null");
            }
            var city = await _cityRepository.GetByIdAsync(id);

            if(city != null)
            {
                await _cityRepository.DeleteAsync(city);
            }

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult CityNotFound()
        {
            return View();
        }
    }
}
