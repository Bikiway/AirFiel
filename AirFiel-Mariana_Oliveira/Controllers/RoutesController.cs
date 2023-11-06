using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var flights = await _routesRepository.GetRoutesAsync();

            var searchView = new SearchViewModel
            {
                From = _cityRepository.GetComboCountriesAndCities(),
                To = _cityRepository.GetComboCountriesAndCities()
            };

            var listOfSearch = new FlightListAndSearchViewModel
            {
                FlightsList = flights,
                searchViewModel = searchView
            };


            return View(listOfSearch);
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



        [AllowAnonymous]
        public async Task<IActionResult> SearchCountry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _cityRepository.GetByIdAsync(id.Value);
            if (country == null)
            {
                return NotFound();
            }

            var flights = (await _routesRepository.GetRoutesAsync())
                .Where(f => f.FromCountryCityID == country.Id);

            var modelList = new List<Routes>();

            var models = new Routes();

            foreach (var item in flights)
            {
                models = await _routesRepository.GetRoutesAsync(item.Id);

                modelList.Add(models);
            }

            var searchView = new SearchViewModel
            {
                From = _cityRepository.GetComboCountriesAndCities(),
                To = _cityRepository.GetComboCountriesAndCities()
            };

            var listOfSearch = new FlightListAndSearchViewModel
            {
                FlightsList = modelList,
                searchViewModel = searchView
            };

            listOfSearch.searchViewModel = searchView;

            return RedirectToAction("Index", "Home", listOfSearch);
        }


        [AllowAnonymous]
        public async Task<IActionResult> SearchHome(SearchViewModel search)
        {
            if (search.FlightDate == null && search.FromCountryCityId == 0 && search.ToCountryCityID == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            if (search.FlightDate != null && search.FromCountryCityId == 0 && search.ToCountryCityID == 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.Depart == search.FlightDate);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                listOfSearch5.searchViewModel = searchView5;

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId != 0 && search.ToCountryCityID == 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.FromCountryCityID == search.FromCountryCityId);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId == 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId != 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.FromCountryCityID == search.FromCountryCityId && f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate != null && search.FromCountryCityId != 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.Depart == search.FlightDate && f.FromCountryCityID == search.FromCountryCityId && f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }

            var modelListEmpty = new List<Routes>();

            var s = new SearchViewModel
            {
                From = _cityRepository.GetComboCities(),
                To = _cityRepository.GetComboCities()
            };

            var fle = new FlightListAndSearchViewModel
            {
                FlightsList = modelListEmpty,
                searchViewModel = s
            };

            return RedirectToAction("Index", fle);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Search(FlightListAndSearchViewModel model)
        {
            var search = model.searchViewModel;

            if (search.FlightDate == null && search.FromCountryCityId == 0 && search.ToCountryCityID == 0)
            {
                return RedirectToAction("Index", "Routes");
            }
            if (search.FlightDate != null && search.FromCountryCityId == 0 && search.ToCountryCityID == 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.Depart == search.FlightDate);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                listOfSearch5.searchViewModel = searchView5;

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId != 0 && search.ToCountryCityID == 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.FromCountryCityID == search.FromCountryCityId);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId == 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate == null && search.FromCountryCityId != 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.FromCountryCityID == search.FromCountryCityId && f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }


            if (search.FlightDate != null && search.FromCountryCityId != 0 && search.ToCountryCityID != 0)
            {
                var flights = (await _routesRepository.GetRoutesAsync())
                    .Where(f => f.Depart == search.FlightDate && f.FromCountryCityID == search.FromCountryCityId && f.ToCountryCityId == search.ToCountryCityID);

                var modelList = new List<Routes>();

                var models = new Routes();

                foreach (var item in flights)
                {
                    models = await _routesRepository.GetRoutesAsync(item.Id);

                    modelList.Add(models);
                }

                var searchView5 = new SearchViewModel
                {
                    From = _cityRepository.GetComboCountriesAndCities(),
                    To = _cityRepository.GetComboCountriesAndCities()
                };

                var listOfSearch5 = new FlightListAndSearchViewModel
                {
                    FlightsList = modelList,
                    searchViewModel = searchView5
                };

                return RedirectToAction("Index", listOfSearch5);
            }

            var modelListEmpty = new List<Routes>();

            var s = new SearchViewModel
            {
                From = _cityRepository.GetComboCities(),
                To = _cityRepository.GetComboCities()
            };

            var fle = new FlightListAndSearchViewModel
            {
                FlightsList = modelListEmpty,
                searchViewModel = s
            };

            return RedirectToAction("Index", fle);

        }      
    }

}




