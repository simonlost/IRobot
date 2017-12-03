using IRobot.Interfaces;
using NLog;

namespace IRobot.Models
{
    public class Board : IBoard
    {
        public int Rows { get;}
        public int Columns { get;}
        private Logger _logger;

        /// <summary>
        /// Construct the board the toy robot will be moving over
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Board(int rows, int columns)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("Board has been created");
            Rows = rows;
            Columns = columns;
        }

        /// <summary>
        /// Determine whether or not the position passed in is allowed for the board in question
        /// </summary>
        /// <param name="position">The position being tested</param>
        /// <returns>Returns true or false</returns>
        public bool IsPositionValid(IPosition position)
        {
            _logger.Info($"Validation has been called against position, x: {position.GetX()}, y: {position.GetY()}");
            return position.GetX() < Columns && position.GetX() >= 0 &&
                   position.GetY() < Rows && position.GetY() >= 0;
        }
    }
}