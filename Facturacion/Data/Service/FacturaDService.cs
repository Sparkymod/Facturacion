using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Models
{
    public class FacturaDService
    {
        public async Task<int> GetLastRno()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                if (!context.FacturasDs.Any())
                {
                    return 0;
                }
                FacturasD? result = await context.FacturasDs.LastOrDefaultAsync(ct);
                return result == null ? 0 : result.Rno;
            }
            catch (Exception ex)
            {
                return new();
            }

        }

        public async Task<FacturasD> Add(FacturasD entity)
        {
            CancellationTokenSource source = new();
            source.CancelAfter(2000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext Context = new();
                Context.FacturasDs.Add(entity);
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
