using Newtonsoft.Json;

namespace PMCS.API.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            SetResponseParameters(context);
            LogException(context, ex);

            var errorMessage = JsonConvert.SerializeObject(new
            {
                ErrorMessage = ex.Message, 
                StatusCode = context.Response.StatusCode 
            });

            return context.Response.WriteAsync(errorMessage);
        }
        private void LogException(HttpContext? context, Exception ex)
        {
            _logger.LogWarning(ex, $"{ex.Message}");
            _logger.LogWarning(ex, $"Exception occured in PATH: {context?.Request.Path}");
        }

        private void SetResponseParameters(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
