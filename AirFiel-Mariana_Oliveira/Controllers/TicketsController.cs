using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsRepository _ticketRepository;
        private readonly IAirplanesRepository _airplanesRepository;
        private readonly IRoutesRepository _routesRepository;
        private readonly ICitiesRepository _cityRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TicketsController(ITicketsRepository ticketsRepository, IAirplanesRepository airplanesRepository, IRoutesRepository routesRepository, ICitiesRepository citiesRepository, IEmployeeRepository employeeRepository)
        {
            _airplanesRepository = airplanesRepository;
            _routesRepository = routesRepository;
            _cityRepository = citiesRepository;
            _employeeRepository = employeeRepository;
            _ticketRepository = ticketsRepository;
        }

        // GET: TicketsController

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            var model = await _ticketRepository.GetAllTicketsAsync(this.User.Identity.Name);
            return View(model);
        }

        // GET: TicketsController/Create
        [Authorize(Roles = "Customer")]
       // [Authorize(Roles = "Anonymous")]
        public async Task<ActionResult> Create()
        {
            var model = await _ticketRepository.GetTicketsClientInfo(this.User.Identity.Name);
            return View(model);
        }

        public IActionResult AddTicket(TicketsViewModel tvm, int id)
        {
            var model = new TicketsViewModel
            {
                FirstName = tvm.FirstName,
                LastName = tvm.LastName,
                CC = tvm.CC,
                NIF = tvm.NIF,
                UserName = User.Identity.Name,
                Age = tvm.Age,
                Passengers = 1,
                PricePerTicketId = tvm.PricePerTicketId,
                IdaEVolta = tvm.IdaEVolta,
                routesId = tvm.routesId,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketsViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _ticketRepository.AddTicketToBoughtTickets(model, this.User.Identity.Name);
                return RedirectToAction("Create");
            }

            return View(model);
        }


        public async Task<IActionResult> DeleteTicket(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _ticketRepository.DeletePurchasedTicket(Id.Value);
            return RedirectToAction("Create");
        }


        public async Task<IActionResult> Increase(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _ticketRepository.HowManyPassengersItWillBe(Id.Value, 1);
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Decrease(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            await _ticketRepository.HowManyPassengersItWillBe(Id.Value, -1);
            return RedirectToAction("Create");
        }


        public async Task<IActionResult> ConfirmReservation()
        {
            var response = await _ticketRepository.ConfirmTicketAsync(this.User.Identity.Name);

            if (response)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        public async Task<IActionResult> SaveTicket(int? Id)
        {
            if (Id == null)
            { return NotFound(); }

            var ticket = await _ticketRepository.GetByIdAsync(Id.Value);

            if (ticket == null)
            {
                return NotFound();
            }

            var model = new SaveTicketIdViewModel
            { Id = ticket.Id };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SaveTicket(SaveTicketIdViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _ticketRepository.SaveTicket(model);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
