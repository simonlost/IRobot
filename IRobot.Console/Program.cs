using System;

namespace IRobot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureService theService = new ConfigureService();
            theService.Start();
        }
    }
}
