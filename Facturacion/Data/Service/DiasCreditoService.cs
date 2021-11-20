using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class DiasCreditoService
    {
        public async Task<List<DiasCredito>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.DiasCreditos.ToListAsync();
        }
    }
}
