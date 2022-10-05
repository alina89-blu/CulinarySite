using CulinarySite.Api.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CulinarySite.Api.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
