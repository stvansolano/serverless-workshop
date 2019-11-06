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
    public static class SignalRNegotiate
    {
        [FunctionName("SignalRNegotiate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "negotiate")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "broadcast")]SignalRConnectionInfo info, 
            ILogger log)
        {
            return await Task.FromResult(
                info != null
                ? (ActionResult)new OkObjectResult(info)
                : new NotFoundObjectResult("Failed to load SignalR Info."));
        }
    }
}
