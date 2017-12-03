using IRobot.Interfaces;

namespace IRobot.Models
{
    public class Position : IPosition
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Get current X posiiton
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
            return _x;
        }

        /// <summary>
        /// Set current X position
        /// </summary>
        /// <param name="x">int</param>
        public void SetX(int x)
        {
            _x = x;
        }

        /// <summary>
        /// Get current Y position
        /// </summary>
        /// <returns></returns>
        public int GetY()
        {
            return _y;
        }

        /// <summary>
        /// Set current Y position
        /// </summary>
        /// <param name="y">int</param>
        public void SetY(int y)
        {
            _y = y;
        }
    }
}
