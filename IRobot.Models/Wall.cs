using System.Runtime.CompilerServices;
using IRobot.Interfaces;
using NLog;

namespace IRobot.Models
{
    public class Wall : IWall
    {
        private Position _position;
        private Logger _logger;
        private bool _wallHasBeenPlaced;

        public Wall()
        {
            _wallHasBeenPlaced = false;
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("A wall has been created");
        }
        public string Report()
        {
            _logger.Info($"This wall has received a request to Report it's state");
            return $"Position of wall: {_position.GetX()}, {_position.GetY()}";
        }

        /// <summary>
        /// Place Wall
        /// </summary>
        /// <param name="pos">Place wall at position provided</param>
        public void Place(IPosition pos)
        {
            if (!_wallHasBeenPlaced)
            {
                _position = (Position) pos;
                _logger.Info($"Wall as been placed at position: {pos.GetX()}, {pos.GetY()}");
            }
            else
            {
                _logger.Info($"Attempt made to place Wall that had already been placed, into position: {pos.GetX()}, {pos.GetY()}");
            }
        }
    }
}