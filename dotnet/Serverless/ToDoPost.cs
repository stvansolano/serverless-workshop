using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace Serverless
{
    public static class ToDoPost
    {
        [FunctionName("ToDoPost")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var connection = Environment.GetEnvironmentVariable ("MongoDbConnection");
            var databaseName = Environment.GetEnvironmentVariable ("MongoDbDatabase");
            var collectionName = Environment.GetEnvironmentVariable ("MongoDbCollection");

            var client = new MongoClient (connection);
            var database = client.GetDatabase (databaseName);

            IMongoCollection<MyTodo> collection = database.GetCollection<MyTodo> (collectionName);

            if (!req.ContentType.ToLower().Contains("application/json"))
            {
                return new BadRequestObjectResult("Expected Json Content-Type");
            }
            var json = await req.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<MyTodo[]>(json);

            await collection.InsertManyAsync(data, new InsertManyOptions { IsOrdered = true});

            return new OkObjectResult(JsonConvert.SerializeObject(data));
        }
    }
}
