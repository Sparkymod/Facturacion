using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class TiposFiscalService
    {
        public async Task<List<TiposFiscal>> GetAllAsync()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.TiposFiscals.ToListAsync(ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }
    }
}
