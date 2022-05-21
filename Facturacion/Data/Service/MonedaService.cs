using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class MonedaService
    {
        public async Task<List<Moneda>> GetAllAsync()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.Monedas.ToListAsync(ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }
    }
}
