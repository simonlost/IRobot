using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using IRobot.Interfaces;
using IRobot.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using IRobot = IRobot.Interfaces.IRobot;

namespace IRobot.Console
{
    public class ConfigureService
    {
        protected ILoggerFactory _loggerFactory { get; }
        private ILogger _logger;
        private Task monitorTask;
        private IServiceProvider serviceProvider;

        public void Start()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            //setup our DI
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddScoped<Logger>();
            services.AddSingleton<Interfaces.IRobot, Robot>();
            services.AddSingleton<ISimulator, Simulator>();
            services.AddSingleton<IBoard>(s => new Board(5,5));
            services.AddSingleton<ICommandProcessor, CommandProcessor>();
            services.AddSingleton<IRunSimulator, RunSimulator>();
            services.AddOptions();
            serviceProvider = services.BuildServiceProvider();
            var sim = serviceProvider.GetService<IRunSimulator>();
            sim.Start();
        }
    }
}