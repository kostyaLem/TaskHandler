using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.DataAccess.Models;

namespace TaskHandler.DataAccess.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepo(TaskDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<TaskData>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task AddAsync(TaskData taskInfo)
        {
            await _dbContext.Tasks.AddAsync(taskInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
