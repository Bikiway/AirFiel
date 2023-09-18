using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class API : DbContext
    {
        public API(DbContextOptions<API> options) : base(options)
        {
            
        }

        public DbSet<API> AllCities { get; set; } = null;
    }
}
