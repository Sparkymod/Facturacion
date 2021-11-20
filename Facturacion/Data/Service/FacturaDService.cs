using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Models
{
    public class FacturaDService
    {
        public async Task<int> GetLastRno()
        {
            using FacturaDbContext context = new();
            if (!context.FacturasDs.Any())
            {
                return 0;
            }
            FacturasD? result = await context.FacturasDs.LastOrDefaultAsync();
            return result == null ? 0 : result.Rno;
        }

        public async Task<FacturasD> Add(FacturasD entity)
        {
            try
            {
                using FacturaDbContext Context = new();
                Context.FacturasDs.Add(entity);
                await Context.SaveChangesAsync();
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
