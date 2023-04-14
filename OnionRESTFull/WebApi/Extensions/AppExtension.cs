using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class AppExtension
    {
        public static void UseErrorHandlerMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddlewares>();
        }

        public static void UseTimeMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<TimeMiddlewares>();
        }
    }
}