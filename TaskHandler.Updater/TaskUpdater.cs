using System;
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

        public async Task<TaskData[]> ProcessTasks()
        {
            var tasks = _messageHandler.ReceiveAll(new BinaryMessageFormatter())
                                       .Select(x => x.Body as TaskData)?.ToArray() ?? new TaskData[0];

            _taskRepo.BeginTransaction();

            foreach (var task in tasks)
                await _taskRepo.AddAsync(task);

            _taskRepo.EndTransaction();

            return tasks;
        }
    }
}
