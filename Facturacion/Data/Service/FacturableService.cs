using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class FacturableService
    {
        public async Task<Facturable?> Get(short id)
        {
            using FacturaDbContext context = new();
            return await context.Facturables.FindAsync(id);
        }

        public async Task<List<Facturable>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.Facturables.ToListAsync();
        }
    }
}
