namespace RainfallApi.Extensions
{
    public static class CorsExtension
    {
        public static IApplicationBuilder UseCorsWithDefaultPolicy(this IApplicationBuilder app)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            return app;
        }
    }
}
