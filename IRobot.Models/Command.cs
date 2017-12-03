using IRobot.Enumerators;
using IRobot.Interfaces;

namespace IRobot.Models
{
    /// <summary>
    /// POC - Command filled in from parsed input from console
    /// </summary>
    public class Command : ICommand
    {
        public Commands Cmd { get; set; }
        public Position Pos { get; set; }
        public Facing Face { get; set; }
        public string Who { get; set; } //TODO: Impliment use of this
        public bool IsCommandFormatValid { get; set; }
    }
}