using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    [Authorize]
    public class RoutesController : Controller
    {
        private readonly IRoutesRepository _routesRepository;
        private readonly IAirplanesRepository _airplanesRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICitiesRepository _cityRepository;

        public RoutesController(IRoutesRepository routesRepository, IAirplanesRepository airplanesRepository, IEmployeeRepository employeeRepository, ICitiesRepository cityRepository)
        {
            _routesRepository = routesRepository;
            _airplanesRepository = airplanesRepository;
            _employeeRepository = employeeRepository;
            _cityRepository = cityRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _routesRepository.GetRoutesAsync(this.User.Identity.Name);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = await _routesRepository.GetDetailsTempsAsync(this.User.Identity.Name);
                return View(model);
            }

        public IActionResult AddRoutes()
        {
            var model = new AddRouteViewModel
            {
                priceId = 1,
                QuantityOfTravels = 1,
                Return = DateTime.MinValue,
                Depart = DateTime.MinValue,
                Plane = _airplanesRepository.GetComboAirplanes(),
                Origem = _cityRepository.GetComboCities(),
                Destino = _cityRepository.GetComboCities(),
                Pilot = _employeeRepository.GetComboEmployees(),
                CoPilot = _employeeRepository.GetComboEmployees(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRoutes(AddRouteViewModel model)
        {
            if (ModelState.IsValid)
            {         
                await _routesRepository.AddItemToRouteAsync(model, this.User.Identity.Name);
                return RedirectToAction("Create");
            }

            return View(model);
        }

    
        public async Task<IActionResult> DeleteRoutes(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _routesRepository.DeleteTempAsync(Id.Value);
            return RedirectToAction("Create", "Index");
        }


        public async Task<IActionResult> IncreaseTravels(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _routesRepository.ModifyRoutesDetailsTempQuantityPerMonthAsync(Id.Value, 1);
            return RedirectToAction("Create");
        }


        public async Task<IActionResult> DecreaseTravels(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _routesRepository.ModifyRoutesDetailsTempQuantityPerMonthAsync(Id.Value, -1);
            return RedirectToAction("Create");
        }

     
        public async Task<IActionResult> ConfirmRoute()
        {
            var response = await _routesRepository.ConfirmRouteAsync(this.User.Identity.Name);

            if (response)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

       
        public async Task<IActionResult> SaveRoute(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var route = await _routesRepository.GetByIdAsync(Id.Value);

            if (route == null)
            {
                return NotFound();
            }

            var model = new SaveRouteIdViewModel
            {
                Id = route.Id,
            };

            return View(model);
        }

      
        [HttpPost]
        public async Task<IActionResult> SaveRoute(SaveRouteIdViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _routesRepository.SaveRoute(model);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
