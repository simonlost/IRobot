using System;
using System.ComponentModel;
using IRobot.Enumerators;
using IRobot.Interfaces;
using NLog;

namespace IRobot.Models
{
    public class Simulator : ISimulator
    {
        private readonly ICommandProcessor _cmdProcessor;
        private readonly Logger _logger;
        private bool _isRunning;
        private readonly IBoard _board;
        private readonly Interfaces.IRobot _robot;
        public Simulator(ICommandProcessor theProcessor, IBoard theBoard, Interfaces.IRobot theRobot)
        {
            _isRunning = true;
            _board = theBoard;
            _robot = theRobot;
            _cmdProcessor = theProcessor;
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("The simulator has been created");
        }

        /// <summary>
        /// Returns whether or not the simulation is still running
        /// </summary>
        /// <returns>Returns true or false</returns>
        public bool IsRunning()
        {
            return _isRunning;
        }

        /// <summary>
        /// Pass command input onto processor and then move robot as per parsed instructions if required.
        /// </summary>
        /// <param name="input">the input from the console application</param>
        /// <returns>returns a string for outputting data to the screen</returns>
        public string ProcessCommand(string input)
        {
            Command cmd;
            try
            {
                cmd = (Command)_cmdProcessor.ProcessCommand(input);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            if (!cmd.IsCommandFormatValid)
            {
                return $"The {cmd.Cmd.ToString()} was in an invalid format";
            }
            switch (cmd.Cmd)
            {
                case Commands.EXIT:
                    _isRunning = false;
                    return "Application closing";
                case Commands.MOVE:
                    var pos = _robot.PositionAfterMove();
                    if (pos != null && _board.IsPositionValid(pos))
                    {
                        _robot.Move();
                    }
                    return null;
                case Commands.LEFT:
                    _robot.Left();
                    return null;
                case Commands.RIGHT:
                    _robot.Right();
                    return null;
                case Commands.PLACE:
                    if (_board.IsPositionValid(cmd.Pos))
                    {
                        _robot.Place(cmd.Pos, cmd.Face);
                    }
                    return null;
                case Commands.REPORT:
                    return _robot.Report();
                default:
                    _logger.Error("Something has gone. This should not have been reached");
                    return "Something has gone. This should not have been reached";
            }
        }
    }
}