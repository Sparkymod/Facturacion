using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class MonedaService
    {
        public async Task<List<Moneda>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.Monedas.ToListAsync();
        }
    }
}
