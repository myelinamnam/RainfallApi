using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using RainfallApi.Core.Models;
using RainfallApi.Extensions;
using RainfallApi.Handlers;
using System.Reflection;

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
builder.Services.AddSwaggerBearer();

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
app.UseMiddleware<ExceptionHandleMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();