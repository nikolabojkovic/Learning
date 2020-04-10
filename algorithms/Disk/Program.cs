using System;

namespace Disk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        // call a couple of times to detest each sensor (on evry call)
        static Direction Detect(int sensonIndentity)
        {
            
        }


    }

    public enum Direction
    {
        None,
        ClockVise,
        AntiClockVise
    }
}
