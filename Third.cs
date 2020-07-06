using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.Diagnostics;

namespace Company.Function
{
    public class Third
    {
        private readonly TelemetryClient telemetryClient;

        /// Using dependency injection will guarantee that you use the same configuration for telemetry collected automatically and manually.
        public Third(TelemetryConfiguration telemetryConfiguration)
        {
            this.telemetryClient = new TelemetryClient(telemetryConfiguration);
        }

        
        [FunctionName("Third")]
        public void Run([QueueTrigger("myqueue", Connection = "rfpstorageq_STORAGE")]string myQueueItem, ILogger log)
        {

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            DateTime start = DateTime.UtcNow;

            var requestActivity = new Activity("Sample: Function 3 Queue Request");
            requestActivity.SetParentId(myQueueItem);
            requestActivity.Start();

            var requestOperation = telemetryClient.StartOperation<RequestTelemetry>(requestActivity);

            telemetryClient.StopOperation(requestOperation);
        }
    }
}
