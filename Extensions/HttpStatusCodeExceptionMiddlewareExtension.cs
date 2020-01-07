using DotNetWebApiSeed.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DotNetWebApiSeed.Extensions
{
    public static class HttpStatusCodeExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}