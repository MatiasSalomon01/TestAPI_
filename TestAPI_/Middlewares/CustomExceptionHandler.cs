using System.Net;
using TestAPI_.Models;

namespace TestAPI_.Middlewares
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAysync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ExceptionHandler(context, exception);
            }
        }

        private async Task ExceptionHandler(HttpContext context, Exception exception)
        {
            if (exception.Message == "csv-headers")
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(new ErrorDetails
                {
                    statusCode = HttpStatusCode.BadRequest,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                }.ToString());
                return;
            }
        }
    }
}
