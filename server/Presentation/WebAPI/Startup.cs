using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace WebAPI {
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавьте сервисы здесь

            //services.AddSingleton(new MongoClient("mongodb://localhost:27017"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    MongoClient client = new MongoClient("mongodb://login:pass@localhost:27017");

                    // обращаемся к базе данных
                    var db = client.GetDatabase("test");    

                    // получаем коллекцию users
                    var collection = db.GetCollection<BsonDocument>("users"); 

                    // для теста добавляем начальные данные, если коллекция пуста
                    if (await collection.CountDocumentsAsync("{}") == 0)
                    {
                        await collection.InsertManyAsync(new List<BsonDocument>
                        {
                            new BsonDocument{ 
                                { "Name", "Tom" },
                                {"Age", 22}
                            },
                            new BsonDocument{ 
                                { "Name", "Bob" },
                                {"Age", 42}
                            }
                        });
                    }
                    var users =  await collection.Find("{}").ToListAsync();

                    // отправляем клиенту все документы из коллекции
                    await context.Response.WriteAsync(users.ToJson());
                });
            });
        }
    }
}