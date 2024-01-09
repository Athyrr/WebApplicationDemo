using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplicationDemo.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Log404Middleware
    {
        private readonly RequestDelegate _next;

        public Log404Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("Error/Error404");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Log404MiddlewareExtensions
    {
        public static IApplicationBuilder Use404Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Log404Middleware>();
        }
    }
}
