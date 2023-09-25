using Microsoft.EntityFrameworkCore;
using System;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using AirFiel_Mariana_Oliveira.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task AddTicketToBoughtTickets(TicketsViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null) 
            {
                string generatePassword = GeneratePassword();

                await AddNewUser(user.UserName, "Customer", generatePassword);
                await _dataContext.SaveChangesAsync();

                return;
            }


            //var userTicket = await _dataContext.Users.FindAsync(model.UserName);
           // var route = await _dataContext.Route.FindAsync(model.routesId);

            //if (userTicket == null) 
            //{
            //    string generatePassword = GeneratePassword();

            //    await AddNewUser(user.UserName, "Customer", generatePassword);
            //    await _dataContext.SaveChangesAsync();
            //}

            var ticketDetailsTemp = await _dataContext.TicketDetailsTemps
                .Where(tdt => tdt.user == user && tdt.user == user)
                .FirstOrDefaultAsync();

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
                    IdaEVolta = model.IdaEVolta,
                   
                   // PricePerTicket = route.PricePerTicket,
                    UserName = model.UserName,
                    user = user,
                };

                _dataContext.TicketDetailsTemps.Add(ticketDetailsTemp);
            }

            else
            {
                ticketDetailsTemp.Passengers += model.Passengers;
                _dataContext.TicketDetailsTemps.Update(ticketDetailsTemp);
            }

            await _dataContext.SaveChangesAsync();

        }

        public async Task<bool> ConfirmTicketAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if(user == null)
            {
                return false;
            }

            var ticketTemp = await _dataContext.TicketDetailsTemps
                .Include(x => x.user)
                .Where(o => o.user == user)
                .ToListAsync();

            if(ticketTemp == null || ticketTemp.Count == 0)
            {
                return false;
            }

            var details = ticketTemp.Select(o => new TicketsDetails
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                QuantityOfPassengers = o.Passengers,
                PricePerTicket = o.PricePerTicket,
                routesId = o.routesId.Id,
            }).ToList();

            string password = GeneratePassword();
            string role = ticketTemp.FirstOrDefault()?.UserName;
            Task <string> users = (Task<string>)AddNewUser(role, "Customer", password);
            int routesId = ticketTemp.FirstOrDefault()?.routesId.Id??0;
            var capacities = GetCapacitiesFromRoutes(routesId);
            var routeId = GetIdFromRoutes(routesId);
            //var pricePerTicket = GetPricePerTicketFromRoutes(routesId);

            var ticket = new Tickets
            {
                ClientFirstName = details.FirstOrDefault()?.FirstName,
                ClientLastName = details.FirstOrDefault()?.LastName,
                DeliveryDate = DateTime.Now,
                capacityReduced1 = (await capacities)[0],
                capacityReduced2 = (await capacities)[1],
                routesId = (await routeId)[0],
                newUserId = users.Result,
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

            if(deleteTicket == null)
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
            if(user == null) 
            { return null; }

            if(await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _dataContext.Ticket
                    .Include(x => x.users)
                    .Include(x => x.Items)
                    //.ThenInclude(x => x.routesId)
                    .OrderByDescending(x => x.ClientFirstName);
            }

            return _dataContext.Ticket
                .Include(x => x.Items)
               // .ThenInclude(x => x.routesId)
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

            if(user == null) { return null; }

            return _dataContext.TicketDetailsTemps
                .Include(o => o.user)
                .Where(o => o.user == user);
        }

        public async Task HowManyPassengersItWillBe(int Id, int quantityOfPassengers)
        {
            var tdt = await _dataContext.TicketDetailsTemps.FindAsync(Id);

            if(tdt == null)
            { return; }

            tdt.Passengers += quantityOfPassengers;

            if(tdt.Passengers > 0) 
            {
                _dataContext.TicketDetailsTemps.Update(tdt);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task SaveTicket(SaveTicketIdViewModel model)
        {
            var ticket = await _dataContext.Ticket.FindAsync(model.Id);
            if(ticket == null) { return; }

            ticket.DeliveryDate = model.DeliveryDate;
            _dataContext.Ticket.Update(ticket);
            await _dataContext.SaveChangesAsync();
        }



        //Helpers
        public async Task<int[]> GetCapacitiesFromRoutes(int Id)
        {
            var capacities = await _dataContext.Route.FirstOrDefaultAsync(o => o.Id == Id);

            if(capacities != null) 
            {
                return new int[] {capacities.Capacity1, capacities.Capacity2};
            }

            return null;
        }



        public async Task<int[]> GetIdFromRoutes(int Idroutes)
        {
            var routes = await _dataContext.Route.FirstOrDefaultAsync(r => r.Id == Idroutes);

            return new int[] {routes.Id};
        }


        public async Task AddNewUser(string userName, string roleName, string password)
        {
            var newUser = new Users
            {
                UserName = userName,
            };

            password = GeneratePassword();
            var roleExist = await _userHelper.GetUserByEmailAsync(newUser.UserName);

            if(roleExist != null) 
            {
                await _userHelper.AddUserToRoleAsync(newUser, roleName);
                await _userHelper.AddUserAsync(newUser, password);
            }
        }

        public async Task<double[]> GetPricePerTicketFromRoutes(int Idroutes)
        {
            var idExists = await _dataContext.Route.FirstOrDefaultAsync(r => r.Id != Idroutes);

            if(idExists != null)
            {
                return new double[] { idExists.PricePerTicket };
            }
            return null;
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
    }
}
