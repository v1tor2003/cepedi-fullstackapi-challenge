using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using CepediFullStack.Application.Validators;
using System.Reflection;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}