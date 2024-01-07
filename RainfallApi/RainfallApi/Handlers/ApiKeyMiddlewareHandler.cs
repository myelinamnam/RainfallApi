using RainfallApi.Core.Models;

namespace RainfallApi.Handlers
{
    /// <summary>
    /// Extension handler class responsible for handling API key authentication.
    /// </summary>
    /// <remarks>
    /// This middleware is responsible for validating API keys provided in incoming requests
    /// and authorizing access to protected resources.
    /// </remarks>
    public class ApiKeyMiddlewareHandler
    {
        private readonly RequestDelegate _next;
        private
        const string APIKEY = "X-Auth-Token";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyMiddlewareHandler"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        //public ApiKeyMiddlewareHandler(RequestDelegate next)
        //{
        //    _next = next;
        //}

        public ApiKeyMiddlewareHandler(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invokes the middleware to process an incoming HTTP request.
        /// </summary>
        /// <param name="context">The HttpContext for the current request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpCode.Unauthorized;
                await context.Response.WriteAsync("Api Key was not provided");

                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
