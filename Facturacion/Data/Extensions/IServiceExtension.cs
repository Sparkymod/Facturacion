using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Extensions
{
    public static class IServiceExtension
    {
        public static void AddAplicationDbContext(this IServiceCollection services)
        {
            services.AddDbContext<FacturaDbContext>(options =>
            {
                options.UseSqlServer(Settings.GetConnectionString());
            });
        }
    }
}
