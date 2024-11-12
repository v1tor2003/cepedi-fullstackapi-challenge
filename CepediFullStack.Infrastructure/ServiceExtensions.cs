using CepediFullStack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CepediFullStack.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext> (options => options.UseSqlite(connectionString));
        }
    }
}