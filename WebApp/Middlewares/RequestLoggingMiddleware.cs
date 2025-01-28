namespace WebApp.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            System.Diagnostics.Debug.WriteLine($"HTTP REQUEST RECEIVED: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
