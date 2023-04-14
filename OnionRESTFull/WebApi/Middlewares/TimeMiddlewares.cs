namespace WebApi.Middlewares
{
    public class TimeMiddlewares
    {
        public TimeMiddlewares(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.Any(q => q.Key == "time")) await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());

            await next(context);
        }

        private readonly RequestDelegate next;
    }
}