using NLog;
using System;
using System.Threading;

namespace TaskHandler.Updater
{
    public class Bootstrapper
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly TaskUpdater _taskUpdater = new TaskUpdater();

        public void Run()
        {
            new Mutex(true, "defauleApplicationName", out bool isCreated);

            if (!isCreated)
            {
                Logger.Warn("Экземпляр приложения уже запущен");
                Console.ReadKey();
            }

            _taskUpdater.ProcessTasks().GetAwaiter().GetResult();
        }
    }
}
