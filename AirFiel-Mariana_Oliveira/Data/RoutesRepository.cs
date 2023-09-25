using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class RoutesRepository : GenericRepository<Routes>, IRoutesRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public RoutesRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        #region
        public async Task AddItemToRouteAsync(AddRouteViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return;
            }

            var airplanes = await _context.airplanes.FindAsync(model.AirplaneId);
            var origin = await _context.City.FindAsync(model.OriginId);
            var destination = await _context.City.FindAsync(model.DestinationId);
            var pilots = await _context.Employee.FindAsync(model.PilotsId);
            var coPilot = await _context.Employee.FindAsync(model.CoPilotsId);

            if (airplanes == null && origin == null && destination == null && pilots == null && coPilot == null)
            {
                return;
            }


            var routeDetailsTemp = await _context.RoutesDetailsTemps
                .Where(rdt => rdt.user == user && rdt.airplanes == airplanes)
                .Where(rdt => rdt.user == user && rdt.originCities == origin)
                .Where(rdt => rdt.user == user && rdt.destinationCities == destination)
                .Where(rdt => rdt.user == user && rdt.pilotEmployees == pilots)
                .Where(rdt => rdt.user == user && rdt.coPilotEmployees == coPilot)
                .FirstOrDefaultAsync();

            if (routeDetailsTemp == null)
            {
                routeDetailsTemp = new RoutesDetailsTemp
                {
                    airplanes = airplanes,
                    originCities = origin,
                    destinationCities = destination,
                    pilotEmployees = pilots,
                    coPilotEmployees = coPilot,
                    Return = model.Return,
                    Depart = model.Depart,
                    FullPrice = model.priceId,
                    TravelsPerMonth = model.QuantityOfTravels,
                    user = user,
                };
                _context.RoutesDetailsTemps.Add(routeDetailsTemp);
            }

            else
            {
                routeDetailsTemp.TravelsPerMonth += model.QuantityOfTravels;
                _context.RoutesDetailsTemps.Update(routeDetailsTemp);
            }

            await _context.SaveChangesAsync();

        }


        public async Task<bool> ConfirmRouteAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return false;
            }

            var routeTemps = await _context.RoutesDetailsTemps
                .Include(p => p.airplanes)
                .Include(p => p.originCities)
                .Include(p => p.destinationCities)
                .Include(p => p.pilotEmployees)
                .Include(p => p.coPilotEmployees)
                .Where(p => p.user == user)
                .ToListAsync();

            if (routeTemps == null || routeTemps.Count == 0)
            {
                return false;
            }

            var detailsInfo = routeTemps.Select(o => new RoutesDetails
            {
                airplanes = o.airplanes,
                originCities = o.originCities,
                destinationCities = o.destinationCities,
                pilotEmployees = o.pilotEmployees,
                coPilotEmployees = o.coPilotEmployees,
                TravelsPerMonth = o.TravelsPerMonth,
                FullPrice = (int)o.FullPrice,
                Return = o.Return,
                Depart = o.Depart,
            }).ToList();

            int airplaneId = routeTemps.FirstOrDefault()?.airplanes.Id ?? 0;
            var capacities = GetCapacitiesFromAirplanes(airplaneId);

            var routes = new Routes
            {
                AirplaneName = detailsInfo.FirstOrDefault()?.airplanes,
                Depart = detailsInfo.FirstOrDefault().Depart,
                Return = detailsInfo.FirstOrDefault().Return,
                Destination = detailsInfo.FirstOrDefault()?.destinationCities,
                Origin = detailsInfo.FirstOrDefault()?.originCities,
                Pilot = detailsInfo.FirstOrDefault()?.pilotEmployees,
                CoPilot = detailsInfo.FirstOrDefault()?.coPilotEmployees,
                GetFullPrice = detailsInfo.FirstOrDefault().FullPrice,
                Capacity1 = (await capacities)[0],
                Capacity2 = (await capacities)[1],
                users = user,
                Items = detailsInfo,
            };

            await CreateAsync(routes);
            _context.RoutesDetailsTemps.RemoveRange(routeTemps);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteTempAsync(int Id)
        {
            var routeDetailsTemp = await _context.RoutesDetailsTemps.FindAsync(Id);

            if (routeDetailsTemp == null)
            {
                return;
            }

            _context.RoutesDetailsTemps.Remove(routeDetailsTemp);
            await _context.SaveChangesAsync();
        }
    

        public async Task<IQueryable<RoutesDetailsTemp>> GetDetailsTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            return _context.RoutesDetailsTemps
                .Include(o => o.airplanes)
                .Include(o => o.originCities)
                .Include(o => o.destinationCities)
                .Include(o => o.pilotEmployees)
                .Include(o => o.coPilotEmployees)
                .Where(o => o.user == user)
                .OrderBy(o => o.destinationCities.Name);
        }

        public async Task<IQueryable<Routes>> GetRoutesAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return _context.Route
                    .Include(o => o.Items)
                    .ThenInclude(o => o.originCities)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.destinationCities)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.pilotEmployees)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.coPilotEmployees)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.airplanes)
                    .Where(o => o.users == user)
                    .OrderByDescending(o => o.AirplaneName); 
            }

                if (await _userHelper.IsUserInRoleAsync(user, "Admin"))
                {
                    return _context.Route
                        .Include(o => o.users)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.originCities)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.destinationCities)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.pilotEmployees)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.coPilotEmployees)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.originCities)
                        .Include(o => o.Items)
                        .ThenInclude(o => o.airplanes)
                        .OrderByDescending(o => o.AirplaneName);
                }

                return _context.Route
                    .Include(o => o.Items)
                    .ThenInclude(o => o.originCities)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.destinationCities)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.pilotEmployees)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.coPilotEmployees)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.airplanes)
                    .Where(o => o.users == user)
                    .OrderByDescending(o => o.AirplaneName);
            
        }

        public async Task<Routes> GetRoutesAsync(int id)
        {
            return await _context.Route.FindAsync(id);
        }

        public async Task ModifyRoutesDetailsTempQuantityPerMonthAsync(int Id, int quantityPerMonth)
        {
            var routesDetailsTemp = await _context.RoutesDetailsTemps.FindAsync(Id);

            if (routesDetailsTemp == null) 
            {
                return;
            }

            routesDetailsTemp.TravelsPerMonth += quantityPerMonth;

            if(routesDetailsTemp.TravelsPerMonth > 0)
            {
                _context.RoutesDetailsTemps.Update(routesDetailsTemp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveRoute(SaveRouteIdViewModel model)
        {
            var route = await _context.Route.FindAsync(model.Id);

            if(route == null)
            {
                return;
            }

            route.Id = model.Id;
            _context.Route.Update(route);
            await _context.SaveChangesAsync();
        }


        public async Task<int[]> GetCapacitiesFromAirplanes(int planeId)
        {
            var plane = await _context.airplanes.FirstOrDefaultAsync(a => a.Id == planeId);

            if (plane != null)
            {
                return new int[] { plane.Capacity1, plane.Capacity2 };
            }

            return new int[] { 0, 0 };
        }

        #endregion
    }
}
