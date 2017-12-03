using IRobot.Interfaces;
using NLog;
using System;

namespace IRobot.Console
{
    public class RunSimulator : IRunSimulator
    {
        private readonly ISimulator _simulator;
        private readonly Logger _logger;
        private bool _applicationStopped;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theSimulator"></param>
        public RunSimulator(ISimulator theSimulator)
        {
            _simulator = theSimulator;
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("The simulator has been created");
        }

        /// <summary>
        /// Start the simulator, and consume input from console
        /// </summary>
        public void Start()
        {
            _logger.Info("The simulator has been started");
            System.Console.WriteLine("=====Toy Robot Simulator ====\nAvailable Robot commands are:\nPLACE x,y,facing\nMOVE\nRIGHT\nLEFT\nREPORT\nEXIT\nPlace robot in valid start position to start...");
            //TODO: remove magic string to resource

             _applicationStopped = false;
            while (!_applicationStopped)
            {
                var command = System.Console.ReadLine();
                try
                {
                    string outPutForConsole = _simulator.ProcessCommand(command.ToUpperInvariant());
                    if (_simulator.IsRunning() == false)
                        _applicationStopped = true;
                    if (!string.IsNullOrEmpty(outPutForConsole))
                        System.Console.WriteLine(outPutForConsole);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex,"Error reading from console while simulator is running");
                    System.Console.WriteLine(ex.Message);
                }
            }
            _logger.Info("The simulator has been stopped");
        }

        public void Stop()
        {
            _applicationStopped = true;
        }
    }
}