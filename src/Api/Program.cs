using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IClaimsPrincipalAccessor, ClaimsPrincipalAccessor>();
                })
                .ConfigureFunctionsWorkerDefaults(worker =>
                {
                    worker.UseMiddleware<ClaimsPrincipalMiddleware>();
                })
                .Build();

            host.Run();
        }
    }
}