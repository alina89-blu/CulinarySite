using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CulinaryApi.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception has occured");

                context.Response.StatusCode = ex switch
                {
                    ValidationException _ => (int)HttpStatusCode.BadRequest,
                    NotFoundException _ => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                await CreateExceptionResponseAsync(context, ex);
            }
        }

        private static Task CreateExceptionResponseAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message + "@@@"
            }
            .ToString());
        }

    }
}

