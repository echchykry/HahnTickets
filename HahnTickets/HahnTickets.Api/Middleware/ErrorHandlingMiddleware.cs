using Newtonsoft.Json;
using System.Net;

namespace HahnTickets.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private async Task<Task> ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = JsonConvert.SerializeObject(new { error = "Something went wrong..." });

            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
