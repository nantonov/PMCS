namespace Notifications.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            SetResponseParameters(context);
            LogException(context, ex);

            return context.Response.WriteAsync($"{ex.Message}\nStatusCode:{context.Response.StatusCode}");
        }

        private void LogException(HttpContext? context, Exception ex)
        {
            _logger.LogWarning(ex, $"{ex.Message}");
            _logger.LogWarning(ex, $"Exception in query: {context?.Request.Path}");
        }

        private void SetResponseParameters(HttpContext context)
        {
            context.Response.ContentType = "application/json";
        }
    }
}
