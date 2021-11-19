using Facturacion.Data.Database;
using Facturacion.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Service
{
    public class ClientService
    {
        public async Task<List<Cliente>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> Get(short id)
        {
            using FacturaDbContext context = new();
            return await context.Clientes.FindAsync(id);
        }
    }

    public class TiposFiscalService
    {
        public async Task<List<TiposFiscal>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.TiposFiscals.ToListAsync();
        }
    }

    public class MonedaService
    {
        public async Task<List<Moneda>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.Monedas.ToListAsync();
        }
    }

    public class FacturableService
    {
        public async Task<Facturable?> Get(short id)
        {
            using FacturaDbContext context = new();
            return await context.Facturables.FindAsync(id);
        }

        public async Task<List<Facturable>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.Facturables.ToListAsync();
        }
    }

    public class DiasCreditoService
    {
        public async Task<List<DiasCredito>> GetAllAsync()
        {
            using FacturaDbContext context = new();
            return await context.DiasCreditos.ToListAsync();
        }
    }

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

    public class ProductoFacturar
    {
        public Facturable? Facturable { get; set; }
        public byte Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioFinal { get { return Precio * Cantidad; } }
    }

    public class Factura
    {
        public FacturasH? FacturaH { get; set; }
        public List<FacturasD>? FacturasD { get; set; }
    }
}
