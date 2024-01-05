using Microsoft.Extensions.DependencyInjection;
using RainfallApi.Application.Interfaces;
using RainfallApi.Infrastructure.Repositories;

namespace RainfallApi.Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRainfallRepository, RainfallRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
