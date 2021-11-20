using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Models
{
    public class FacturaHService
    {
        public async Task<int> GetLastNoFact()
        {
            using FacturaDbContext context = new();
            if (!context.FacturasHes.Any())
            {
                return 0;
            }
            FacturasH? result = await context.FacturasHes.LastOrDefaultAsync();
            return result == null ? 0 : result.NoFact;
        }

        public async Task<FacturasH> Add(FacturasH entity)
        {
            try
            {
                using FacturaDbContext Context = new();
                Context.FacturasHes.Add(entity);
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
