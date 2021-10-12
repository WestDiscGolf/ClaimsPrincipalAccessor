using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class GetWelcome
    {
        private readonly IClaimsPrincipalAccessor _claimsPrincipalAccessor;

        public GetWelcome(IClaimsPrincipalAccessor claimsPrincipalAccessor)
        {
            _claimsPrincipalAccessor = claimsPrincipalAccessor;
        }

        [Function("GetWelcome")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetWelcome");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var msg = new Message { Value = "welcome to Azure Functions!" };
            if (_claimsPrincipalAccessor.Principal?.Identity?.IsAuthenticated == true)
            {
                msg.Value = $"Welcome to Azure Functions {_claimsPrincipalAccessor.Principal.Identity.Name}!!";
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(msg);
            return response;
        }
    }

    public class Message
    {
        public string Value { get; set; }
    }
}
