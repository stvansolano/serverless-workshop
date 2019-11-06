using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Serverless
{
    public static class SignalRTrigger
    {
        [FunctionName("SignalRTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [SignalR(HubName = "broadcast")]IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
             string requestBody = new StreamReader(req.Body).ReadToEnd();

            if (string.IsNullOrEmpty(requestBody))
            {
                return new BadRequestObjectResult("Please pass a payload to broadcast in the request body.");
            }

            await signalRMessages.AddAsync(new SignalRMessage()
            {
                Target = "notify",
                Arguments = new object[] { requestBody }
            });

            return new OkResult();
        }
    }
}
