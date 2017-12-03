using System;

namespace IRobot.Interfaces
{
    public interface IBoard
    {
        bool IsPositionValid(IPosition position);
    }
}
