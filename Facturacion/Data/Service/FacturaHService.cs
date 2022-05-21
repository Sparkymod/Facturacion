using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Models
{
    public class FacturaHService
    {
        public async Task<int> GetLastNoFact()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                if (!context.FacturasHes.Any())
                {
                    return 0;
                }
                FacturasH? result = await context.FacturasHes.LastOrDefaultAsync(ct);
                return result == null ? 0 : result.NoFact;
            }
            catch (Exception ex)
            {
                return new();
            }

        }

        public async Task<FacturasH> Add(FacturasH entity)
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext Context = new();
                Context.FacturasHes.Add(entity);
                await Context.SaveChangesAsync(ct);
            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error($"Error saving changes => {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Error saving changes => {ex}");
            }

            return entity;
        }
    }
}
