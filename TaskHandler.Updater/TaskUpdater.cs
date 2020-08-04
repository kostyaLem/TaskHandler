using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Threading.Tasks;
using TaskHandler.Data;
using TaskHandler.Data.Models;
using TaskHandler.Data.Repositories;
using TaskHandler.QueueService;

namespace TaskHandler.Updater
{
    class TaskUpdater
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ITaskRepo _taskRepo;

        public TaskUpdater()
        {
            _messageHandler = new MessageHandler();
            _taskRepo = new TaskRepo(new TaskDbContext());
        }

        public async Task ProcessTasks()
        {
            var tasks = _messageHandler.ReceiveAll(new BinaryMessageFormatter()).Select(x => x.Body as TaskData)?.ToArray();

            tasks = new List<TaskData>() { new TaskData() { Description = "ewrq" }, new TaskData() { Description = "ewrq" }, new TaskData() { Description = "ewrq" }, new TaskData() { Description = "ewrq" } }.ToArray();

            _taskRepo.BeginTransaction();

            foreach (var task in tasks)
                await _taskRepo.AddAsync(task);

            _taskRepo.EndTransaction();
        }
    }
}
