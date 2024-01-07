using MediatR;
using RainfallApi.Handler.Repositories;

namespace RainfallApi.Extensions
{
    /// <summary>
    /// Extension methods to register MediatR handlers.
    /// </summary>
    public static class AddMediaRHandlers
    { 
        /// <summary>
        /// Registers MediatR handlers.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register MediatR handlers with.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMediaRHandlerExtension(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetRainfallReadingHandlerRepository));
            return services;
        }
    }
}
