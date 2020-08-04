using NLog;
using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace TaskHandler.Updater
{
    public class Bootstrapper
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly TaskUpdater _taskUpdater = new TaskUpdater();
        private static Timer _timer;

        public Bootstrapper()
        {
            _timer = new Timer(10_000);
            _timer.Elapsed += CheckAndUpdate;
        }

        public void Run()
        {
            if (Mutex.TryOpenExisting("ConsoleTaskUpdater", out Mutex _))
            {
                Logger.Warn("Экземпляр приложения уже создан.");
                Console.ReadKey();
            }

            _timer.Start();
        }

        private void CheckAndUpdate(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            try
            {
                var tasks = _taskUpdater.ProcessTasks().GetAwaiter().GetResult();

                if (tasks.Length == 0)
                    Logger.Info("Очередь сообщений пуста.");
                else
                    Logger.Info($"Обработан список задач. [{tasks.Length}]");

            }
            catch (Exception exc)
            {
                Logger.Error(exc, "Ошибка в процессе обработки задач.");
            }

            _timer.Start();
        }
    }
}
