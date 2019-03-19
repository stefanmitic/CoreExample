using System;
using System.Threading;
using System.Threading.Tasks;
using CoreExample.Execution;
using NLog;

namespace CoreExample.Linux
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "CoreExample.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
            
            ExampleEnvironment.InitEnvironment(new ControllerFactoryLinux());
            
            var serviceEntry = new ServiceEntry();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => 
            {
                serviceEntry.OnStop();
                Console.WriteLine("Service exit!");
                cts.Cancel();
            };

            serviceEntry.OnStart(args);

            Console.WriteLine("Waiting for SIGTERM...");

            await Task.Delay(-1, cts.Token);
            Console.WriteLine("Exiting...");

            return 0;
        }
    }
}