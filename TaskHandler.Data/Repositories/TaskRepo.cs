using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepo(TaskDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(TaskData taskData)
        {
            _dbContext.Tasks.Add(taskData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskData>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }
    }
}
