using IRobot.Enumerators;

namespace IRobot.Interfaces
{
    public interface IRobot : IBoardPiece
    {
        void Move();
        void Left();
        void Right();
        void Place(IPosition pos, Facing face);
        IPosition PositionAfterMove();
    }
}