using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _context.SaveChangesAsync();
        }
    }
}
