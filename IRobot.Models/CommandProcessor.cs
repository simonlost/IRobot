using System;
using IRobot.Enumerators;
using IRobot.Interfaces;
using NLog;

namespace IRobot.Models
{

    public class CommandProcessor : ICommandProcessor
    {
        private readonly Logger _logger;

        public CommandProcessor()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("The command processor has been created");
        }

        /// <summary>
        /// Parse and validate inputed commands
        /// </summary>
        /// <param name="command">console input as string</param>
        /// <returns>Returns implimentation of ICommand</returns>
        public ICommand ProcessCommand(string command)
        {
            string[] input = command.Split(' ');
            if (!IsCommandValid(input[0]))
            {
                _logger.Debug($"invalid command received: {command}");
                throw new ArgumentException("Invalid command entered. Please try again using the following formats: PLACE X,Y,(NORTH,SOUTH,EAST,WEST)|MOVE|LEFT|RIGHT|REPORT");
            }
            try
            {
                var cmdValue = Enum.Parse<Commands>(input[0]);
                switch (cmdValue)     
                {
                    case Commands.EXIT:
                        return CreateCommand(Commands.EXIT, input.Length);
                    case Commands.MOVE:
                        return CreateCommand(Commands.MOVE, input.Length);
                    case Commands.LEFT:
                        return CreateCommand(Commands.LEFT, input.Length);
                    case Commands.RIGHT:
                        return CreateCommand(Commands.RIGHT, input.Length);
                    case Commands.PLACE:
                        return ProcessPlaceCommand(input);
                    case Commands.REPORT:
                        return CreateCommand(Commands.REPORT, input.Length);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex,$"Exception thrown using processing of command: {command}");
                throw new ArgumentException("Invalid command entered. Please try again using the following formats: PLACE X,Y,(NORTH,SOUTH,EAST,WEST)|MOVE|LEFT|RIGHT|REPORT");
            }
            return new Command();
        }

        /// <summary>
        /// Validate and process Place command
        /// </summary>
        /// <param name="input">the command string from the console</param>
        /// <returns>an implimentation of the ICommand</returns>
        private ICommand ProcessPlaceCommand(string[] input)
        {
            _logger.Debug("Place command has been received");
            var placeCommand = new Command {Cmd = Commands.PLACE};
            string[] input2 = input[1].Split(','); 
            bool xIsValid = int.TryParse(input2[0], out int x);
            bool yIsValid = int.TryParse(input2[1], out var y);
            bool facingIsValid = Enum.IsDefined(typeof(Facing), input2[2]);
            if ((input.Length != 2) || !xIsValid || !yIsValid || !facingIsValid)
            {
                placeCommand.IsCommandFormatValid = false;
                return placeCommand;
            }
            placeCommand.IsCommandFormatValid = true;
            placeCommand.Pos = new Position(x,y);
            placeCommand.Face = Enum.Parse<Facing>(input2[2]);
            return placeCommand;
        }

        private bool IsCommandValid(string commandToCheck)
        {
            // can do this as forced input to upper
            return Enum.IsDefined(typeof(Commands), commandToCheck);
        }

        /// <summary>
        /// Validate general command
        /// </summary>
        /// <param name="cmd">enum of command</param>
        /// <param name="length">length of array of split data input</param>
        /// <returns>an implimentation of the ICommand</returns>
        private ICommand CreateCommand(Commands cmd, int length)
        {
            _logger.Debug($"{cmd.ToString()} has been received");
            var ICmd = new Command
            {
                Cmd = cmd,
                IsCommandFormatValid = (length <= 1)
            };
            return ICmd;
        }
    }
}
