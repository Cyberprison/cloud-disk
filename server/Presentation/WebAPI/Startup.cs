using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI {
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавьте сервисы здесь
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("hiiiii");
                });
            });
        }
    }
}