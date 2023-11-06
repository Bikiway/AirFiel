using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface IRoutesRepository : IGenericRepository<Routes>
    {
        #region
        Task<IQueryable<Routes>> GetRoutesAsync(); //Tarefa que devolve uma tabela das rotas//Dá-me todas as rotas que o employee adicionou.

        Task<IQueryable<RoutesDetailsTemp>> GetDetailsTempsAsync(string userName); //Dá os users temporários

        Task AddItemToRouteAsync(AddRouteViewModel model, string userName); //Add items

        Task ModifyRoutesDetailsTempQuantityPerMonthAsync(int Id, int quantityPerMonth); //Modifica os items que lá estão.

        Task DeleteTempAsync(int Id);

        Task<bool> ConfirmRouteAsync(string userName);

        Task<Routes> GetRoutesAsync(int id);

        Task SaveRoute(SaveRouteIdViewModel model);

        IEnumerable<SelectListItem> Origins();

        IEnumerable<SelectListItem> Destinations();

        public IQueryable GetAllWithUsers();

        Task<int[]> GetCapacitiesFromAirplanes(int planeId);
        #endregion

    }
}
