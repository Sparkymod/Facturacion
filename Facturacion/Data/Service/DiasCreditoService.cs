using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class DiasCreditoService
    {
        public async Task<List<DiasCredito>> GetAllAsync()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.DiasCreditos.ToListAsync(ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }
    }
}
