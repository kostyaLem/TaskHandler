using System;

namespace TaskHandler.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bootstrapper().Run();
            
            Console.ReadKey();
        }
    }
}
