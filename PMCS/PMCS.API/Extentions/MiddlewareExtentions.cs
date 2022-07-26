using PMCS.API.Middlewares;

namespace PMCS.API.Extentions
{
    public static class MiddlewareExtentions
    {
        public static void AddExceptionMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();
        }
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

   
