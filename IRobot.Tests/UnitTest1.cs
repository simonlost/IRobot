using IRobot.Enumerators;
using IRobot.Interfaces;
using IRobot.Models;
using Moq;
using Moq.Language.Flow;
using Xunit;

namespace IRobot.Tests
{
    public class UnitTest1
    {
#region Robot tests
        [Fact]
        public void TestRobotReport()
        {
            // TODO: Complete test coverage
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.NORTH);
            Assert.Equal("Current position of robot: 1, 1, NORTH", thisRobot.Report());
        }

        [Fact]
        public void TestRobotLeft()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.NORTH);
            thisRobot.Left();
            Assert.Equal("Current position of robot: 1, 1, WEST", thisRobot.Report());
        }

        [Fact]
        public void TestRobotRight()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.NORTH);
            thisRobot.Right();
            Assert.Equal("Current position of robot: 1, 1, EAST", thisRobot.Report());
        }

        [Fact]
        public void TestRobotMoveNorth()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.NORTH);
            thisRobot.Move();
            Assert.Equal("Current position of robot: 1, 2, NORTH", thisRobot.Report());
        }

        [Fact]
        public void TestRobotMoveSouth()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.SOUTH);
            thisRobot.Move();
            Assert.Equal("Current position of robot: 1, 0, SOUTH", thisRobot.Report());
        }

        [Fact]
        public void TestRobotMoveWest()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.WEST);
            thisRobot.Move();
            Assert.Equal("Current position of robot: 0, 1, WEST" , thisRobot.Report());
        }

        [Fact]
        public void TestRobotMoveEast()
        {
            Robot thisRobot = new Robot();
            thisRobot.Place(new Position(1, 1), Facing.EAST);
            thisRobot.Move();
            Assert.Equal("Current position of robot: 2, 1, EAST" , thisRobot.Report());
        }

        [Fact]
        public void TestBoardIsPositionValid()
        {
            Board thisBoard = new Board(5,5);           
            Assert.True(thisBoard.IsPositionValid(new Position(1,1)));
            Assert.False(thisBoard.IsPositionValid(new Position(-1, -1)));
        }

        [Fact]
        public void TestBoardCreation()
        {
            Board thisBoard = new Board(6, 5);
            Assert.True(thisBoard.Rows == 6 );
            Assert.True(thisBoard.Columns == 5);
        }

        [Fact]
        public void TestPositionCreation()
        {
            Position thisPosition = new Position(6, 5);
            Assert.True(thisPosition.GetY() == 5);
            Assert.True(thisPosition.GetX() == 6);
            thisPosition.SetY(2);
            thisPosition.SetX(2);
            Assert.True(thisPosition.GetY() == 2);
            Assert.True(thisPosition.GetX() == 2);
        }

        #endregion
    }
}
