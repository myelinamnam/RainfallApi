using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace RainfallApi.Extensions
{
    public static class MvcExtension
    {
        public static IServiceCollection AddMvcWithAuthorization(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            return services;
        }
    }
}
