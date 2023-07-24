using AirFiel_Mariana_Oliveira.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    [Authorize]
    public class RoutesController : Controller
    {
        private readonly IRoutesRepository _routesRepository;

        public RoutesController(IRoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
