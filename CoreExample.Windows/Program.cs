using System;
using System.Reflection;
using System.ServiceProcess;
using System.Configuration.Install;
using NLog;
using CoreExample.Execution;

namespace CoreExample.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "CoreExample.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;

            var logger = NLog.LogManager.GetCurrentClassLogger();

            Console.WriteLine("UserInteractive...");
            string parameter = string.Concat(args);
            if (parameter.Length > 0)
            {
                try
                {
                    switch (parameter)
                    {
                        case "--install":
                            Console.WriteLine("--install");
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        case "--uninstall":
                            Console.WriteLine("--uninstall");
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                ExampleEnvironment.InitEnvironment(new ControllersFactoryWindows());
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ServiceEntry()
                };

                logger.Info("Starting service...");
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
