namespace IRobot.Interfaces
{
    public interface IWall : IBoardPiece
    {
        /// <summary>
        /// Place wall on board
        /// </summary>
        /// <param name="pos">Postion of wall on board</param>
        void Place(IPosition pos);
    }
}