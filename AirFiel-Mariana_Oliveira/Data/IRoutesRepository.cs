using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface IRoutesRepository : IGenericRepository<Routes>
    {
        Task<IQueryable<Routes>> GetOrderAsync(string userName); //Tarefa que devolve uma tabela de order//Dá-me todas as encomendas de um determinado user.

        Task<IQueryable<RoutesDetailsTemp>> GetDetailsTempsAsync(string userName); //Dá os users temporários

        Task AddItemToOrderAsync(AddRouteViewModel model, string userName); //Add items

        Task ModifyOrderDetailsTempQuantityAsync(int Id, double quantity); //Modifica os items que lá estão.

        Task DeleteTempAsync(int Id);

        Task<bool> ConfirmRouteAsync(string userName);
    }
}
