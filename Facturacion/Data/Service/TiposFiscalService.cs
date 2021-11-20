using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class TiposFiscalService
    {
        public async Task<List<TiposFiscal>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.TiposFiscals.ToListAsync();
        }
    }
}
