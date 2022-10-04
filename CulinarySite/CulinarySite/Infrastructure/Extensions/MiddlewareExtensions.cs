using CulinaryApi.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CulinaryApi.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
