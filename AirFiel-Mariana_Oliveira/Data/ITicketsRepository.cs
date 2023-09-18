using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface ITicketsRepository : IGenericRepository<Tickets>
    {
        #region
        Task<IQueryable<Tickets>> GetAllTicketsAsync(string userName); //Just for Admin Vai buscar os tickets todos. Encomendas do user.

        Task<Tickets> GetInfoTicketAsync(int id);

        Task<bool> ConfirmTicketAsync(string userName);

        Task DeletePurchasedTicket(int Id);

        Task AddTicketToBoughtTickets(TicketsViewModel model, string userName);

        Task<IQueryable<TicketsDetailsTemp>> GetTicketsClientInfo(string userName);

        Task HowManyPassengersItWillBe(int Id, int quantityOfPassengers);

        Task SaveTicket(SaveTicketIdViewModel model);

        Task<int[]> GetCapacitiesFromRoutes(int Id); //Get capacities from routes to diminuish the capacity

        Task<int[]> GetIdFromRoutes(int Idroutes); //Get Id from a route

        Task AddNewUser(string userName, string roleName, string password); //Register new User after buying a ticket.

        Task<double[]> GetPricePerTicketFromRoutes(int Idroutes);

        #endregion
    }
}
