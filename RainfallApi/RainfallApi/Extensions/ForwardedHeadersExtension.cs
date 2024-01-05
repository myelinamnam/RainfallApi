using Microsoft.AspNetCore.HttpOverrides;

namespace RainfallApi.Extensions
{
    public static class ForwardedHeadersExtension
    {
        public static IServiceCollection AddForwardedHeaders(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            return services;
        }
    }
}
