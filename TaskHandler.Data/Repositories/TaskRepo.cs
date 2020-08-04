using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskDbContext _dbContext;
        private DbContextTransaction _transaction;

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

        public void BeginTransaction()
        {
            if (_transaction != null)
                _dbContext.Database.UseTransaction(null);

            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void EndTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (Exception exc)
            {
                _transaction.Rollback();
                throw exc;
            }
        }
    }
}
