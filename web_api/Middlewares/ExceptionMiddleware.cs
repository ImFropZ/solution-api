using web_api.Exceptions;

namespace web_api.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (StatusCodeException e)
            {
                context.Response.Headers.Add("Content-Type", "application/json");
                switch (e)
                {
                    case NotFoundException error:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case BadRequestException error:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                }
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
