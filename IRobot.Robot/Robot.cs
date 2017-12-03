using System;
using IRobot.Models;

namespace IRobot.Robot
{
    public class Robot : Interfaces.IRobot
    {
        private Position _currentPosition;
        private Facing _currentFacing;

        /// <summary>
        /// Rotate robot's facing to the left
        /// </summary>
        public void Left()
        {
            Rotate(-1);
        }

        /// <summary>
        /// Move robot one square in the direction it is currently facing
        /// </summary>
        public void Move()
        {
            switch (_currentFacing)
            {
                case Facing.North:
                    _currentPosition.Y = _currentPosition.Y + 1;
                    break;
                case Facing.East:
                    _currentPosition.X = _currentPosition.X + 1;
                    break;
                case Facing.South:
                    _currentPosition.Y = _currentPosition.Y - 1;
                    break;
                case Facing.West:
                    _currentPosition.X = _currentPosition.X - 1;
                    break;
            }
        }

        /// <summary>
        /// Place the robot on the board
        /// </summary>
        /// <param name="pos">Position object containing the x and y coordinates of the position of the robot</param>
        /// <param name="face">The facing of the robot when placed</param>
        public void Place(Position pos, Facing face)
        {
            _currentPosition = pos;
            _currentFacing = face;
        }

        /// <inheritdoc />
        /// <summary>
        /// Report the robots current position and facing
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return $"Current position of robot: {_currentPosition.X}, {_currentPosition.Y}, {_currentFacing}";
        }

        /// <summary>
        /// Rotate robot's facing to the right
        /// </summary>
        public void Right()
        {
            Rotate(1);
        }

        private void Rotate(int rotateNumber)
        {
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
