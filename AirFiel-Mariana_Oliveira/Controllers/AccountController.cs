using Microsoft.AspNetCore.Mvc;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
