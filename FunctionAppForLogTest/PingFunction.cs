using FunctionAppForLogTest.Aspect;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionAppForLogTest
{
    public static class PingFunction
    {
        [LoggerAspect]
        [FunctionName("PingFunction")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            string name = string.Empty;
            log.Info("C# HTTP trigger function processed a request.");

            SomeService someService = new SomeService();
            someService.DoSomething().GetAwaiter().GetResult();

            return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
    }
}