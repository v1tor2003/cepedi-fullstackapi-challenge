using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;
//using CepediFullStack.Infrastructure.Repositories;
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
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<AppDbContext> (options => options.UseSqlite(connectionString));

            //services.AddScoped<IRepository, ConcreteRepository>
        }
    }
}