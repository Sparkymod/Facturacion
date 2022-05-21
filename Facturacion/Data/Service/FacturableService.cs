using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class FacturableService
    {
        public async Task<Facturable?> Get(short id)
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.Facturables.FindAsync(id,ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }

        public async Task<List<Facturable>> GetAllAsync()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.Facturables.ToListAsync(ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }
    }
}
