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
            using FacturaDbContext context = new();
            return await context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> Get(short id)
        {
            using FacturaDbContext context = new();
            return await context.Clientes.FindAsync(id);
        }
    }
}
