namespace IRobot.Interfaces
{
    public interface ISimulator
    {
        bool IsRunning();
        string ProcessCommand(string input);
    }
}