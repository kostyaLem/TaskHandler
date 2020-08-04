using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskContext _dbContext;

        public TaskRepo(TaskContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<TaskData>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task AddAsync(TaskData taskInfo)
        {
            _dbContext.Tasks.Add(taskInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
