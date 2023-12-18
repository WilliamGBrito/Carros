using Business.Interfaces;
using Business.Notificacoes;
using Business.Services;
using Data.Context;
using Data.Repository;

namespace ApiCarros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICarroRepository, CarroRepository>();

            // Business
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}