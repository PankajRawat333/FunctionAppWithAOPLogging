using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FunctionAppForLogTest.Aspect;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionAppForLogTest
{
    public static class PingFunction2
    {
        [AsyncLoggerAspect]
        [FunctionName("PingFunction2")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            SomeService someService = new SomeService();
            await someService.DoSomething();

            return req.CreateResponse(HttpStatusCode.OK, "Hello ");
        }
    }
}