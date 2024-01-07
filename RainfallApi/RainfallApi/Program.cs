using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.HttpOverrides;
using RainfallApi.Core.Models;
using RainfallApi.Extensions;
using RainfallApi.Handlers;
using RainfallApi.Infrastructure;
using RainfallApi.Application.Interfaces;
using RainfallApi.Handler.Interfaces;
using RainfallApi.Handler.Repositories;
using RainfallApi.Helper;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddDotNetEnvironmentVariables("WebApi__");
builder.Configuration.AddDotNetDotEnvVariables(optional: true);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddHttpClient();
builder.Services.AddOptions();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("WebApi"));
builder.Services.AddForwardedHeaders();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IGetRainfallReadingHandlerRepository, GetRainfallReadingHandlerRepository>();
builder.Services.AddScoped<IRainfallReadingHelper, RainfallReadingHelper>();
builder.Services.AddSwaggerBearer();
builder.Services.AddMediaRHandlerExtension();
var app = builder.Build();
app.UseSwaggerWithUIBearer();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseCorsWithDefaultPolicy();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddlewareHandler>();
app.UseMiddleware<ExceptionHandleMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();