using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketsRepository _ticketRepository;
        private readonly IAirplanesRepository _airplanesRepository;
        private readonly IRoutesRepository _routesRepository;
        private readonly ICitiesRepository _cityRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private DataContext _dataContext;
        private readonly UserManager<Users> _userManager;
        private readonly IUserHelper _userHelper;

        public TicketsController(ITicketsRepository ticketsRepository, IAirplanesRepository airplanesRepository, IRoutesRepository routesRepository, ICitiesRepository citiesRepository, IEmployeeRepository employeeRepository, DataContext dataContext, IUserHelper userHelper, UserManager<Users> userManager)
        {
            _airplanesRepository = airplanesRepository;
            _routesRepository = routesRepository;
            _cityRepository = citiesRepository;
            _employeeRepository = employeeRepository;
            _ticketRepository = ticketsRepository;
            _dataContext = dataContext;
            _userHelper = userHelper;
            _userManager = userManager;
        }

        // GET: TicketsController

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            var model = await _ticketRepository.GetAllTicketsAsync(this.User.Identity.Name);
            return View(model);
        }

        // GET: TicketsController/Create
        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            var model = await _ticketRepository.GetTicketsClientInfo(this.User.Identity.Name);
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddTicket(TicketsViewModel tvm, int id)
        {
            var routes = await _routesRepository.GetByIdAsync(id);
           // var idaVolta = await _ticketRepository.IdaEVoltaBool(id);
            var ticket = await _ticketRepository.GetPricePerTicketFromRoutes(id);

            // Get the capacities for the specific route identified by 'id'
            var route = await _dataContext.Route
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    Capacity1 = c.Capacity1,
                    Capacity2 = c.Capacity2
                })
                .FirstAsync();

            var model = new TicketsViewModel
            {
                FirstName = tvm.FirstName,
                LastName = tvm.LastName,
                CC = tvm.CC,
                NIF = tvm.NIF,
                UserName = User.Identity.Name,
                Age = tvm.Age,
                Passengers = 1,
                PassengersFirstClass = 0,
                PassengersSecondClass = 0,
                SeatNumber1 = tvm.SeatId1,
                SeatNumber2 = tvm.SeatId2,
                SeatId1 = tvm.SeatId1,
                SeatId2 = tvm.SeatId2,
                NumberOfSeats1 = route.Capacity1,
                NumberOfSeats2 = route.Capacity2,
                Items = await _ticketRepository.GetAllReservationsFromRoutes(routes.Id),
                routesId = routes.Id,
                PricePerTicketId = Convert.ToInt32(ticket),
                IdaEVolta = tvm.IdaEVolta,
            };

            ViewData["N1Seats"] = model.NumberOfSeats1;
            ViewData["N2Seats"] = model.NumberOfSeats2;
            ViewData["FlightId"] = routes.Id;

            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketsViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _ticketRepository.AddTicketToBoughtTickets(model, model.UserName);
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


        public async Task<IActionResult> ConfirmReservation(int id)
        {
            try
            {
                var response = await _ticketRepository.ConfirmTicketAsync(this.User.Identity.Name);
                var route = await _ticketRepository.GetIdFromRoutes(id);

                if (response)
                {
                    await _ticketRepository.UpdateRoutesAirplanesCapacityAsync(route);
                    return RedirectToAction("PageReview");
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors here.
                return RedirectToAction("Error"); // Redirect to an error page or take appropriate action.
            }
        }


        public async Task<ActionResult> PageReview()
        {
            try
            {
                var model = await _ticketRepository.GetAllTicketsAsync(this.User.Identity.Name);
                return View(model);
            }
            catch (Exception ex)
            {
                ex.InnerException.Message.ToString();
            }

            return View("Create");
        }


        public async Task<IActionResult> ReservationConfirmed(int? Id)
        {
            try
            {
                if (Id == null)
                { return NotFound(); }

                var ticket = await _ticketRepository.GetByIdAsync(Id.Value);

                if (ticket == null)
                {
                    return NotFound();
                }

                var model = new UserSpaceViewModel
                {
                    Id = ticket.Id,
                    FirstName = ticket.ClientFirstName,
                    LastName = ticket.ClientLastName,
                    UserName = ticket.UserName,
                    CC = ticket.CC,
                    NIF = ticket.NIF,
                    Origin = ticket.Origin,
                    Destination = ticket.Destination,
                    Depart = ticket.Depart.ToShortDateString(),
                    Return = ticket.Return.ToShortDateString(),
                    PassengersFirstClass = ticket.PassengersFirstClass.Value,
                    PassengersSecondClass = ticket.PassengersSecondClass.Value,
                    TotalPrice = ticket.TotalPrice,
                };

                return View(model);
            }

            catch(Exception ex) 
            { ex.Message.ToString(); }

            return View("PageReview");
        }


        [HttpPost]
        public async Task<IActionResult> ReservationConfirmed(UserSpaceViewModel model)
        {
            await _ticketRepository.ReservationConfirmed(model);
            return RedirectToAction("Index", "Home");
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
