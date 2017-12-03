using System;
using IRobot.Interfaces;
using NLog;
using IRobot.Enumerators;

namespace IRobot.Models
{
    public class Robot : Interfaces.IRobot
    {
        private Position _currentPosition;
        private Facing _currentFacing;
        private readonly Logger _logger;
        private bool _robotOnBoard;

        public Robot()
        {
            _robotOnBoard = false;
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("A robot has been created");
        }

        /// <summary>
        /// Rotate robot's facing to the left
        /// </summary>
        public void Left()
        {
            if (!_robotOnBoard) return;
            Rotate(-1);
            _logger.Info("Robot as rotated left");

        }

        /// <summary>
        /// Calculates and returns the position of the robot if it were to receive a MOVE command
        /// </summary>
        /// <returns>The position the robot would be located at if requested to move</returns>
        public IPosition PositionAfterMove()
        {
            if (!_robotOnBoard) return null;
            return CalculateMove();
        }

        /// <summary>
        /// Calculate and return the result of a MOVE command
        /// </summary>
        /// <returns>The position of the robot would be located at if it were to move</returns>
        private IPosition CalculateMove()
        {
            Position potentialPosition = new Position(0,0);
            switch (_currentFacing)
            {
                case Facing.NORTH:
                    potentialPosition.SetY(_currentPosition.GetY() + 1);
                    potentialPosition.SetX(_currentPosition.GetX());
                    _logger.Info("Robot as moved North");
                    break;
                case Facing.EAST:
                    potentialPosition.SetX(_currentPosition.GetX() + 1);
                    potentialPosition.SetY(_currentPosition.GetY());
                    _logger.Info("Robot as moved East");
                    break;
                case Facing.SOUTH:
                    potentialPosition.SetY(_currentPosition.GetY() - 1);
                    potentialPosition.SetX(_currentPosition.GetX());
                    _logger.Info("Robot as moved South");
                    break;
                case Facing.WEST:
                    potentialPosition.SetX(_currentPosition.GetX() - 1);
                    potentialPosition.SetY(_currentPosition.GetY());                   
                    _logger.Info("Robot as moved West");
                    break;
            }
            return potentialPosition;
        }

        /// <summary>
        /// Move robot one square in the direction it is currently facing
        /// </summary>
        public void Move()
        {
            if (!_robotOnBoard) return;
            _currentPosition = (Position)CalculateMove();
        }

        /// <summary>
        /// Place the robot on the board
        /// </summary>
        /// <param name="pos">Position object containing the x and y coordinates of the position of the robot</param>
        /// <param name="face">The facing of the robot when placed</param>
        public void Place(IPosition pos, Facing face)
        {
            _robotOnBoard = true;
            _currentPosition = (Position)pos;
            _currentFacing = face;
            _logger.Info($"Robot as been placed at position: {pos.GetX()}, {pos.GetY()}, facing: {face.ToString()}");
        }

        /// <inheritdoc />
        /// <summary>
        /// Report the robots current position and facing
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (!_robotOnBoard) return "";
            _logger.Info("Robot has received a request to Report it's state");
            return $"Current position of robot: {_currentPosition.GetX()}, {_currentPosition.GetY()}, {_currentFacing}";
        }

        /// <summary>
        /// Rotate robot's facing to the right
        /// </summary>
        public void Right()
        {
            if (!_robotOnBoard) return;
            Rotate(1);
            _logger.Info("Robot as rotated right");
        }

        /// <summary>
        /// Rotate the robot left or right
        /// </summary>
        /// <param name="rotateNumber"></param>
        private void Rotate(int rotateNumber)
        {
            if ((rotateNumber != -1) && (rotateNumber != 1))
            {
                _logger.Error($"Invalid rotateNumber value {rotateNumber} received");
                return;
            }
            var facings = (Facing[])Enum.GetValues(typeof(Facing));
            Facing newFacing;
            if ((_currentFacing + rotateNumber) < 0)
                newFacing = facings[facings.Length - 1];
            else
            {
                var index = ((int)(_currentFacing + rotateNumber)) % facings.Length;
                newFacing = facings[index];
            }
            _currentFacing = newFacing;
        }
    }
}
