using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICitiesRepository _citiesRepository;

        public HomeController(ILogger<HomeController> logger, ICitiesRepository citiesRepository)
        {
            _logger = logger;
            _citiesRepository = citiesRepository;
        }


        public IActionResult Index()
        {
            var model = new SearchViewModel
            {
                From = _citiesRepository.GetComboCountriesAndCities(),
                To = _citiesRepository.GetComboCountriesAndCities()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
