using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class TicketsRepository : GenericRepository<Tickets>, ITicketsRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly IRoutesRepository _routesRepository;

        public TicketsRepository(DataContext dataContext, IUserHelper userHelper, IRoutesRepository routesRepository) : base(dataContext)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _routesRepository = routesRepository;
        }

        public async Task<IEnumerable<TicketsDetailsTemp>> GetAllReservationsFromRoutes(int id)
        {
            return await _dataContext.TicketDetailsTemps.Where(o => o.routeId == id).ToListAsync();
        }

        public async Task AddTicketToBoughtTickets(TicketsViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null)
            {
                return;
            }

            else
            {               
                var idaVolta = await IdaEVoltaBool(model.Id);
                var route = await _dataContext.Route.FindAsync(model.routesId);

                if (route == null)
                {
                    return;
                }

                var ticketDetailsTemp = await _dataContext.TicketDetailsTemps
                    .Where(tdt => tdt.user == user && tdt.routesId == route)
                    .Where(tdt => tdt.user == user && tdt.user == user)
                    .FirstOrDefaultAsync();


                var seats = await GetCapacitiesFromRoutes(route.Id);
                var item = await GetAllReservationsFromRoutes(route.Id);

                if (ticketDetailsTemp == null)
                {
                    ticketDetailsTemp = new TicketsDetailsTemp
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = user.Age,
                        Passengers = model.Passengers,
                        CC = model.CC,
                        NIF = model.NIF,
                        IdaEVolta = idaVolta,
                        routesId = route,
                        PricePerTicket = model.PricePerTicketId,
                        UserName = model.UserName,
                        PassengersFirstClass = model?.PassengersFirstClass,
                        PassengersSecondClass = model?.PassengersSecondClass,
                        SeatNumber1Class = model?.SeatNumber1,
                        SeatsNumber2Class = model?.SeatNumber2,
                        user = user,
                    };

                    _dataContext.TicketDetailsTemps.Add(ticketDetailsTemp);
                }

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ConfirmTicketAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return false;
            }

            var ticketTemp = await _dataContext.TicketDetailsTemps
                .Include(x => x.user)
                .Include(x => x.routesId)
                .Where(o => o.user == user)
                .ToListAsync();

            if (ticketTemp == null || ticketTemp.Count == 0)
            {
                return false;
            }

            var routesId = await GetIdFromRoutes(ticketTemp.FirstOrDefault().routesId.Id);
            var capacities = await GetCapacitiesFromRoutes(routesId);
            // var prices = await GetPricePerTicketFromRoutes(routesId);
            var origin = await GetOriginAirport(routesId);
            var destination = await GetDestinationAirport(routesId);
            var idaVolta = await IdaEVoltaBool(routesId);
            var depart = await GetDepartFromRoutes(routesId);
            var returned = await GetReturnFromRoutes(routesId);

            var details = ticketTemp.Select(o => new TicketsDetails
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                CC = o.CC,
                NIF = o.NIF,
                QuantityOfPassengers = o.Passengers,
                PricePerTicket = o.PricePerTicket,
                routesId = routesId,
                IdaEVolta = o.IdaEVolta,
                PassengersFirstClass = o?.PassengersFirstClass,
                PassengersSecondClass = o?.PassengersSecondClass,
                SeatNumber1Class = o?.SeatNumber1Class,
                SeatsNumber2Class = o?.SeatsNumber2Class,
            }).ToList();

            //if (user != null)
            //{
            //    string password = GeneratePassword();
            //    string role = ticketTemp.FirstOrDefault()?.UserName;
            //    Task<string> users = (Task<string>)AddNewUser(role, "Customer", password);

            //    var ticketForNewUser = new Tickets
            //    {
            //        newUserId = users.Result,
            //    };
            //}

            var ticket = new Tickets
            {
                ClientFirstName = details.FirstOrDefault().FirstName,
                ClientLastName = details.FirstOrDefault().LastName,
                CC = details.FirstOrDefault().CC,
                NIF = details.FirstOrDefault().NIF,
                DeliveryDate = DateTime.Now,
                capacityReduced1 = (capacities)[0],
                capacityReduced2 = (capacities)[1],
                routesId = routesId,
                Origin = origin,
                PassengersFirstClass = details.FirstOrDefault()?.PassengersFirstClass,
                PassengersSecondClass = details.FirstOrDefault()?.PassengersSecondClass,
                Destination = destination,
                Return = returned,
                Depart = depart,
                SeatNumber1Class = details.FirstOrDefault()?.SeatNumber1Class,
                SeatsNumber2Class = details.FirstOrDefault()?.SeatsNumber2Class,
                UserName = user.UserName,
                users = user,
                Items = details,
            };

            await CreateAsync(ticket);
            _dataContext.TicketDetailsTemps.RemoveRange(ticketTemp);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task DeletePurchasedTicket(int Id)
        {
            var deleteTicket = await _dataContext.TicketDetailsTemps.FindAsync(Id);

            if (deleteTicket == null)
            {
                return;
            }

            _dataContext.TicketDetailsTemps.Remove(deleteTicket);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Tickets>> GetAllTicketsAsync(string userName)
        {
            //Só buscar as reservas de cada cliente

            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            { return null; }

            if (await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _dataContext.Ticket
                    .Include(x => x.users)
                    .Include(x => x.Items)
                    //.ThenInclude(x => x.routesId)
                    .OrderByDescending(x => x.ClientFirstName);
            }

            return _dataContext.Ticket
                .Include(x => x.Items)
                //.ThenInclude(x => x.routesId)
                .Where(o => o.users == user)
                .OrderByDescending(o => o.ClientFirstName);
        }


        public async Task<Tickets> GetInfoTicketAsync(int id)
        {
            return await _dataContext.Ticket.FindAsync(id);
        }

        public async Task<IQueryable<TicketsDetailsTemp>> GetTicketsClientInfo(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null) { return null; }

            return _dataContext.TicketDetailsTemps
                .Include(o => o.user)
                .Where(o => o.user == user);
        }

        public async Task<bool> IdaEVoltaBool(int Id)
        {
            var tdt = await _dataContext.TicketDetailsTemps.FindAsync(Id);

            if (tdt == null)
            { return false; }

            if (tdt.IdaEVolta == true)
            {
                tdt.PricePerTicket *= 2;
            }

            _dataContext.TicketDetailsTemps.Update(tdt);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task UpdateRoutesAirplanesCapacityAsync(int ticketId)
        {
            var ticket = await _dataContext.Ticket.FindAsync(ticketId);

            if (ticket == null)
            {
                return;
            }

            var route = await _dataContext.Route.FindAsync(ticket.routesId);

            if (route == null)
            {
                return;
            }

            var c1 = route.Capacity1 - ticket.PassengersFirstClass.Value;
            var c2 = route.Capacity2 - ticket.PassengersSecondClass.Value;

            if (c1 >= 0 && c2 >= 0)
            {
                route.Capacity1 = c1;
                route.Capacity2 = c2;

                _dataContext.Route.Update(route);
                await _dataContext.SaveChangesAsync();
            }
        }


        public async Task SaveTicket(SaveTicketIdViewModel model)
        {
            var ticket = await _dataContext.Ticket.FindAsync(model.Id);
            if (ticket == null) { return; }

            ticket.DeliveryDate = model.DeliveryDate;
            _dataContext.Ticket.Update(ticket);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ReservationConfirmed(UserSpaceViewModel model)
        {
            var ticket = await _dataContext.Ticket.FindAsync(model.Id);

            if (ticket == null) { return; }

            ticket.Id = model.Id;
            _dataContext.Ticket.Update(ticket);
            await _dataContext.SaveChangesAsync();
        }


        //Helpers
        public async Task<int[]> GetCapacitiesFromRoutes(int Id)
        {
            var route = await _dataContext.Route
               .Where(r => r.Id == Id)
               .Select(r => new { r.Capacity1, r.Capacity2 })
               .FirstOrDefaultAsync();

            if (route != null)
            {
                return new int[] { route.Capacity1, route.Capacity2 };
            }

            return null;
        }



        public async Task<int> GetIdFromRoutes(int Idroutes)
        {
            var route = await _dataContext.Route
                .Where(r => r.Id == Idroutes)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            return route;
        }


        public async Task AddNewUser(string userName, string roleName, string password)
        {
            var newUser = new Users
            {
                UserName = userName,
            };

            password = GeneratePassword();
            var roleExist = await _userHelper.GetUserByEmailAsync(newUser.UserName);

            if (roleExist != null)
            {
                await _userHelper.AddUserToRoleAsync(newUser, roleName);
                await _userHelper.AddUserAsync(newUser, password);
            }
        }

        public async Task<double> GetPricePerTicketFromRoutes(int Idroutes)
        {
            var route = await _dataContext.Route
               .Where(r => r.Id == Idroutes)
               .Select(r => r.PricePerTicket)
               .FirstOrDefaultAsync();

            return route;
        }

        private string GeneratePassword()
        {
            const string chars = "ABCDEFGIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, 6)
                .Select(c => c[random.Next(c.Length)]).ToArray());
        }

        public IQueryable GetAllWithUsers()
        {
            return _dataContext.Ticket.Include(t => t.users);
        }

        public async Task<string> GetOriginAirport(int IdRoute)
        {
            var origin = await _dataContext.Route
                .Where(r => r.Id == IdRoute)
                .Select(r => r.Origin.FullAirportAndCityName)
                .FirstOrDefaultAsync();

            return origin;
        }

        public async Task<string> GetDestinationAirport(int IdRoute)
        {
            var destination = await _dataContext.Route
                .Where(r => r.Id == IdRoute)
                .Select(r => r.Destination.FullAirportAndCityName)
                .FirstOrDefaultAsync();

            return destination;
        }

        public async Task<DateTime> GetDepartFromRoutes(int IdRoute)
        {
            var departDateString = await _dataContext.Route
              .Where(d => d.Id == IdRoute)
              .Select(d => d.Depart.ToShortDateString())
              .FirstOrDefaultAsync();

            if (DateTime.TryParse(departDateString, out DateTime departDate))
            {
                return departDate;
            }
            else
            {
                throw new Exception("Failed to parse Return date.");
            }
        }

        public async Task<DateTime> GetReturnFromRoutes(int IdRoute)
        {
            var returnedDateString = await _dataContext.Route
                .Where(d => d.Id == IdRoute)
                .Select(d => d.Return.ToShortDateString())
                .FirstOrDefaultAsync();

            if (DateTime.TryParse(returnedDateString, out DateTime returnedDate))
            {
                return returnedDate;
            }
            else
            {
                throw new Exception("Failed to parse Return date.");
            }
        }

        public async Task<int> GetSeatNumber1Async(int flightId)
        {
            var seatNumber1 = await _dataContext.Route
                .Where(f => f.Id == flightId)
                .Select(f => f.Capacity1)
                .FirstOrDefaultAsync();

            return seatNumber1;
        }

        public async Task<int> GetSeatNumber2Async(int flightId)
        {
            var seatNumber2 = await _dataContext.Route
                 .Where(f => f.Id == flightId)
                 .Select(f => f.Capacity2)
                 .FirstOrDefaultAsync();

            return seatNumber2;
        }

    }
}
