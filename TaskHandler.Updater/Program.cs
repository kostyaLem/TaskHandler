using System;
using System.Threading;

namespace TaskHandler.Updater
{
    class Program
    {


        static void Main(string[] args)
        {
            Mutex mutex = new Mutex(true, "defauleApplicationName", out bool isCreated);

            if (!isCreated)
            {
                Console.WriteLine("Обработчик собщений уже запущен...");
                Console.ReadKey();
            }


        }
    }
}
