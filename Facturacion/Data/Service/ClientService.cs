using Facturacion.Data.Database;
using Facturacion.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public class ClientService
    {
        public async Task<List<Cliente>> GetAllAsync()
        {
            CancellationTokenSource source = new();
            source.CancelAfter(5000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.Clientes.ToListAsync(ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }

        public async Task<Cliente?> Get(short id)
        {
            CancellationTokenSource source = new();
            source.CancelAfter(5000);
            var ct = source.Token;
            try
            {
                using FacturaDbContext context = new();
                return await context.Clientes.FindAsync(id,ct);
            }
            catch (Exception ex)
            {
                return new();
            }

        }
    }
}
