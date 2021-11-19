using Facturacion.Data.Database;
using Facturacion.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Service
{
    public class ClientService
    {
        public async Task<List<Cliente>> GetAllClientAsync()
        {
            using FacturaDbContext context = new();
            return await context.Clientes.ToListAsync();
        }
    }

    public class TiposFiscalService
    {
        public async Task<List<TiposFiscal>> GetAllTiposFiscalsAsync()
        {
            using FacturaDbContext context = new();
            return await context.TiposFiscals.ToListAsync();
        }
    }
}
