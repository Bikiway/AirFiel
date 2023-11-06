using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface ITicketsRepository : IGenericRepository<Tickets>
    {
        #region

        Task<IEnumerable<TicketsDetailsTemp>> GetAllReservationsFromRoutes(int id);

        Task<IQueryable<Tickets>> GetAllTicketsAsync(string userName); //Just for Admin Vai buscar os tickets todos. Encomendas do user.

        Task<Tickets> GetInfoTicketAsync(int id);

        Task<bool> ConfirmTicketAsync(string userName);

        Task DeletePurchasedTicket(int Id);

        Task AddTicketToBoughtTickets(TicketsViewModel model, string userName);

        Task<IQueryable<TicketsDetailsTemp>> GetTicketsClientInfo(string userName);

        Task <bool> IdaEVoltaBool(int Id);

        Task SaveTicket(SaveTicketIdViewModel model);

        Task UpdateRoutesAirplanesCapacityAsync(int ticketId);
        #endregion

        //Helpers

        #region

        Task<int[]> GetCapacitiesFromRoutes(int Id); //Get capacities from routes to diminuish the capacity

        Task<int> GetIdFromRoutes(int Idroutes); //Get Id from a route

        Task<string> GetOriginAirport(int IdRoute);

        Task<string> GetDestinationAirport(int IdRoute);

        Task<DateTime> GetDepartFromRoutes(int IdRoute);

        Task<DateTime> GetReturnFromRoutes(int IdRoute);

        Task AddNewUser(string userName, string roleName, string password); //Register new User after buying a ticket.

        Task<double> GetPricePerTicketFromRoutes(int Idroutes);

        Task ReservationConfirmed(UserSpaceViewModel model);

        public IQueryable GetAllWithUsers();

        Task<int> GetSeatNumber1Async(int flightId);

        Task<int> GetSeatNumber2Async(int flightId);

        #endregion
    }
}
