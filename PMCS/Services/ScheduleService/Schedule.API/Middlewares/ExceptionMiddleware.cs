using Serilog;

namespace Schedule.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
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
            finally
            {
                Log.CloseAndFlush();
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
            Log.Error(ex, $"{ex.Message}");
            Log.Error(ex, $"Exception in query: {context?.Request.Path}");
        }

        private void SetResponseParameters(HttpContext context)
        {
            context.Response.ContentType = "application/json";
        }
    }
}
