using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class First
    {
// Create a single, static HttpClient
        private static HttpClient httpClient = new HttpClient();

        [FunctionName("First")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("First HTTP trigger function processed a request.");

            var responseMessage = await httpClient.GetAsync(
                "https://......"
                );

            return new OkObjectResult(responseMessage);
        }
    }
}
