using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebAPI {
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Создание хоста
            var hostBuilder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    // Регистрация сервисов
                    
                });

                webBuilder.Configure(app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync("hiiiii");
                        });
                    });
                });
            });

            // 2. Построение хоста
            var host = hostBuilder.Build();

            // 3. Запуск хоста
            host.Run();
        }
    }
}