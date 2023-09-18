using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Controllers.API_Controllers
{
    public class CityNamesController : Controller
    {
        Uri baseAddress = new Uri("https://flagcdn.com/en/codes.json");
        private readonly HttpClient _httpClient;

        public CityNamesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<Cit>
            return View();
        }
    }
}
