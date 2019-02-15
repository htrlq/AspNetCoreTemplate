using Core.Template.Middleware._Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Template
{
    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Add Exception Handler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            services.AddSingleton<IExceptionHandler, ExceptionHandler>();
            return services;
        }

        /// <summary>
        /// Use Exception Middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
