namespace IRobot.Interfaces
{
    public interface ICommandProcessor
    {
        ICommand ProcessCommand(string command);
    }
}