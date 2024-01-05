using Microsoft.OpenApi.Models;
using System.Reflection;

namespace RainfallApi.Extensions
{
    public static class BearerAuthExtension
    {
        public static IServiceCollection AddSwaggerBearer(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rainfall Api",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Sorted",
                        Url = new Uri("https://www.sorted.com")
                    },
                    Description = "An API which provides rainfall reading data",
                });
                s.AddServer(new OpenApiServer
                {
                    Url = "https://www.sorted.com",
                    Description = "Rainfall Api"
                });
                OpenApiTag tag = new OpenApiTag
                {
                    Name = "Rainfall",
                    Description = "Operations relating to rainfall"
                };

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                s.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "ApiKey must appear in header",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "XApiKey",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });

                var key = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    },
                    In = ParameterLocation.Header
                };

                var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
                s.AddSecurityRequirement(requirement);
            });
            return services;
        }



        public static IApplicationBuilder UseSwaggerWithUIBearer(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall Api v1.0"));
            return app;
        }
    }
}
