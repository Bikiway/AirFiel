using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DbSet<Airplanes> airplanes { get; set; }

        public DbSet<Cities> City { get; set; }

        public DbSet<Employees> Employee { get; set; }

        public DbSet<Tickets> Ticket { get; set; }

        public DbSet<TicketsDetails> TicketDetails { get; set; }

        public DbSet<TicketsDetailsTemp> TicketDetailsTemps { get; set; }

        public DbSet<Routes> Route { get; set; }

        public DbSet<RoutesDetails> RouteDetails { get; set; }

        public DbSet<RoutesDetailsTemp> RoutesDetailsTemps { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

    }
}
