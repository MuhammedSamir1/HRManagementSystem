namespace HRManagementSystem.Data.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                if (ex.InnerException is not null)
                    throw ex.InnerException;
            }
        }
    }
}
