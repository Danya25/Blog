using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyBlog.Common;

namespace MyBlog.Middleware
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;

        public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            /*var endpointFeature = context.Features[typeof(IEndpointFeature)] as IEndpointFeature;
            var endpoint = endpointFeature?.Endpoint;
            var routePattern = (endpoint as RouteEndpoint)?.RoutePattern?.RawText;*/
            
            _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");
            
            var problemDetails = ex.ToErrorMethodResult<object>();
            
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(result);
        }
    }
}