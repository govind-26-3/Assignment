using System.Net;
using BoilerPlate.Application.Exceptions;

namespace BoilerPlate.Api.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {

            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext , ex );
            }
        }

        private static async Task<Task> HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode  statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            
            httpContext.Response.StatusCode = (int) statusCode;
            var response = new
            {
                StatusCode =httpContext.Response.StatusCode,
                Message = ex.Message
            };
            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
