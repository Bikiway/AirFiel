using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DbSet<Airplanes> airplains { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}
