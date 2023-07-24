using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class RoutesRepository : GenericRepository<Routes>, IRoutesRepository
    {
        private readonly DataContext _dataContext;
        
        public RoutesRepository(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }

        public Task AddItemToOrderAsync(AddRouteViewModel model, string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ConfirmRouteAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTempAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<RoutesDetailsTemp>> GetDetailsTempsAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<Routes>> GetOrderAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task ModifyOrderDetailsTempQuantityAsync(int Id, double quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
