using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace CoreExample.Execution.WebServer
{
    public class SelfHostedServer
    {
        public static IWebHost CreateSelfWebHostKestrel(int port)
        {
            IWebHost server;
            server = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel(
                options =>
                {
                    options.Limits.MaxConcurrentConnections = 100;
                    options.Listen(IPAddress.Any, port, listenOptions =>
                    {
                    });
                })
                .Build();

            return server;
        }
    }
}
