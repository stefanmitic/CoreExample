using CoreExample.Execution.WebServer;
using Microsoft.AspNetCore.Hosting;
using NLog;
using System;
using System.ServiceProcess;
using System.Threading;

namespace CoreExample.Windows
{
    public partial class ServiceEntry : ServiceBase
    {
        IWebHost server = null;
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        void CreateWebServer(int port)
        {
            try
            {
                ThreadPool.SetMinThreads(200, 100);

                server = SelfHostedServer.CreateSelfWebHostKestrel(port);
                var serverTask = server.RunAsync();
                if (serverTask.Exception != null)
                {
                    logger.Error("StartWebServer => Internal exception: " + serverTask.Exception.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error("StartWebServer => Exception: " + e.ToString());
            }
        }
        public ServiceEntry()
        {
            InitializeComponent();
            CanShutdown = true;
        }

        protected override void OnStart(string[] args)
        {
            if (args.Length >= 1)
            {
                logger.Info("Starting server on port: " + args[0]);
                CreateWebServer(Int32.Parse(args[0]));
            }
            else
            {
                logger.Info("Starting server on port: " + 8080);
                CreateWebServer(8080);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
